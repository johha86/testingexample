namespace Contoso.Payment.API.DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {
        public Models.Entities.Payment Create(string orderCode, int customerId, float amount)
        {
            return new Models.Entities.Payment() { Amount = amount, CustomerId = customerId, OrderCode = orderCode, Id = Random.Shared.Next(1, 30) };

            // throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Entities.Payment Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
