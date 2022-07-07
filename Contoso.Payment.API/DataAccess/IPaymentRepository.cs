namespace Contoso.Payment.API.DataAccess
{
    public interface IPaymentRepository
    {
        Task<Models.Entities.Payment> Create(string orderCode, int customerId, float amount);

        Task<Models.Entities.Payment> Get(int id);

        Task Delete(int id);
    }
}
