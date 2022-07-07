using Contoso.Payment.API.Models.DTOs;

namespace Contoso.Payment.API.Logic
{
    public interface IPaymentProcessor
    {
        PaymentResponse CreateNewPayment(PaymentRequest request);

        PaymentResponse GetPayment(int id);
    }
}
