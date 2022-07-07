namespace Contoso.Payment.API.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string OrderCode { get; set; } = null!;
        public int CustomerId { get; set; }
        public float Amount { get; set; }
    }
}
