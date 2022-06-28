using Capta_Teste.Customer.Api.Data.ValueObject;

namespace Capta_Teste.Customer.Api.Repository.Interface
{
    public interface ICustomerStatusRepository
    {
        Task<IEnumerable<CustomerStatusVO>> FindAll();
    }
}
