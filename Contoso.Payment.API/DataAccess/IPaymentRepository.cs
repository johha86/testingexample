namespace Contoso.Payment.API.DataAccess
{
    public interface IPaymentRepository
    {
        Models.Entities.Payment Create(string orderCode, int customerId, float amount);

        Models.Entities.Payment Get(int id);

        void Delete(int id);
    }
}
