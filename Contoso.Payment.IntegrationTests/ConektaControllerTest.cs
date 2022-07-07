using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Contoso.Payment.API;
using Newtonsoft.Json;
using Contoso.Payment.API.Models.DTOs;
using System.Text;
using System.Net.Http;

namespace Contoso.Payment.IntegrationTests
{
    public class ConektaControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ConektaControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Should_Return_An_Existing_Payment()
        {
            //  Arrange
            var client = _factory.CreateClient();
            var request = new PaymentRequest("asd-45fg", 2, 40.0f);
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //  Act
            var responseCreation = await client.PostAsync("/api/conekta/payment", data);
            var contentCreation = await responseCreation.Content.ReadAsStringAsync();
            var paymentCreation = JsonConvert.DeserializeObject<PaymentResponse>(contentCreation);
            var response = await client.GetAsync($"/api/conekta/{paymentCreation.Id}");

            //  Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Create_A_New_Payment()
        {
            //  Arrange
            var client = _factory.CreateClient();
            var request = new PaymentRequest("asd-45fg",2, 40.0f);
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //  Act
            var response = await client.PostAsync("/api/conekta/payment",data);

            //  Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var payment = JsonConvert.DeserializeObject<PaymentResponse>(content);
            Assert.Equal("asd-45fg", payment.OrderCode);
        }
    }
}