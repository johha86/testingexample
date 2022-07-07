using Contoso.Payment.API.DataAccess;
using Contoso.Payment.API.Models.DTOs;

namespace Contoso.Payment.API.Logic
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly IPaymentRepository _repository;
        private readonly CostCalculator _costCalculator;

        public PaymentProcessor(IPaymentRepository repository)
        {
            _repository = repository;
            _costCalculator = new CostCalculator();
        }

        public PaymentResponse CreateNewPayment(PaymentRequest request)
        {
            if (string.IsNullOrEmpty(request.OrderCode))
            {
                throw new ArgumentException();
            }
            if (request.Amount <= 0)
            {
                throw new ArgumentException();
            }

            var finalAmount = _costCalculator.CalculatePayment(request.Amount, Region.SouthAmerica);
            var payment = _repository.Create(request.OrderCode, request.CustomerId, finalAmount);

            return new PaymentResponse(payment.Id, payment.OrderCode);
        }

        public PaymentResponse GetPayment(int id)
        {
            var payment = _repository.Get(id);

            return new PaymentResponse(payment.Id, payment.OrderCode);
        }
    }
}
