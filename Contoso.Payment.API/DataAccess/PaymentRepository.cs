namespace Contoso.Payment.API.DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {
        Dictionary<int, Models.Entities.Payment> _data = new Dictionary<int, Models.Entities.Payment>();

        public Task<Models.Entities.Payment> Create(string orderCode, int customerId, float amount)
        {
            var payment = new Models.Entities.Payment() { Amount = amount, CustomerId = customerId, OrderCode = orderCode, Id = Random.Shared.Next(1, 30) };
            _data.Add(payment.Id, payment);
            return Task.FromResult(payment);

            // throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            await Task.FromResult(_data.Remove(id));
        }

        public Task<Models.Entities.Payment> Get(int id)
        {
            var result = _data[id];
            return Task.FromResult(result);
        }
    }
}
