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
        public async Task<IActionResult> GetResponse(int id)
        {
            try
            {
                var result = _processor.GetPayment(id);

                return await Task.FromResult(Ok(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Problem(ex.Message));
            }
        }

        [HttpPost("payment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            try
            {
                var result = _processor.CreateNewPayment(request);

                return await Task.FromResult(Ok(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Problem(ex.Message));
            }

            
        }
    }
}
