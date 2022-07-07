namespace Contoso.Payment.API.Models.DTOs
{
    public record PaymentRequest(string OrderCode, int CustomerId, float Amount);
}
