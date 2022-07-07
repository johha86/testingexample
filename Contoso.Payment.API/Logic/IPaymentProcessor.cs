using Contoso.Payment.API.Models.DTOs;

namespace Contoso.Payment.API.Logic
{
    public interface IPaymentProcessor
    {
        Task<PaymentResponse> CreateNewPayment(PaymentRequest request);

        Task<PaymentResponse> GetPayment(int id);
    }
}
