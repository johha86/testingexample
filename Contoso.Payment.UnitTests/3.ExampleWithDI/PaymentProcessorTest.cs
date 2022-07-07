using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Contoso.Payment.API.Logic;
using Contoso.Payment.API.DataAccess;
using Contoso.Payment.API.Models.DTOs;

namespace Contoso.Payment.UnitTests._3.ExampleWithDI
{
    public class PaymentProcessorTest
    {
        [Fact]
        public void Should_Create_PaymentResponse()
        {
            //  Arrange
            string orderCode = "asd-45fg";
            const int customerId = 2;
            const float amount = 40.0f;
            const int id = 23;
            var costCalculator = new CostCalculator();
            float tax = costCalculator.GetTaxFromRegion(Region.SouthAmerica);

            // ---------- Mocking ------------
            var repositoryMock = new Mock<IPaymentRepository>();
            _ = repositoryMock
                .Setup(m => m.Create(
                    It.Is<string>(e => e == orderCode),
                    It.Is<int>(e => e == customerId),
                    It.Is<float>(e => e == (amount * tax) + amount)))
                .Returns(new API.Models.Entities.Payment() { Id = id, Amount = amount, CustomerId = customerId, OrderCode = orderCode });
            var processor = new PaymentProcessor(repositoryMock.Object);
            // ---------------------------------
            var request = new PaymentRequest(orderCode, customerId, amount);

            //  Act
            var response = processor.CreateNewPayment(request);

            //  Assert
            Assert.True(response.Id != 0);
        }
    }
}
