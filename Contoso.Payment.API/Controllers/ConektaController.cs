using Contoso.Payment.API.Logic;
using Contoso.Payment.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConektaController : ControllerBase
    {
        private readonly IPaymentProcessor _processor;

        public ConektaController(IPaymentProcessor processor)
        {
            _processor = processor ?? throw new ArgumentNullException();
        }
        [HttpGet()]
        [Route("{id:int}")]
        public async Task<PaymentResponse> GetResponse(int id)
        {
           var result = _processor.GetPayment(id);

            return await Task.FromResult(result);
        }

        [HttpPost("payment")]
        public async Task<PaymentResponse> ProcessPayment([FromBody] PaymentRequest request)
        {
            var result = _processor.CreateNewPayment(request);

            return await Task.FromResult(result);
        }
    }
}
