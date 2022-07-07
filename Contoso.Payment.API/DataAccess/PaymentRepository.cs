namespace Contoso.Payment.API.DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {
        Dictionary<int, Models.Entities.Payment> _data = new Dictionary<int, Models.Entities.Payment>();

        public Models.Entities.Payment Create(string orderCode, int customerId, float amount)
        {
            var payment = new Models.Entities.Payment() { Amount = amount, CustomerId = customerId, OrderCode = orderCode, Id = Random.Shared.Next(1, 30) };
            _data.Add(payment.Id, payment);
            return payment;

            // throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _data.Remove(id);
        }

        public Models.Entities.Payment Get(int id)
        {
            var result = _data[id];
            return result;
        }
    }
}
