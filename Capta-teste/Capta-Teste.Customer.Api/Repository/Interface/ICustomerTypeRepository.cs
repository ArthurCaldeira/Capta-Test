using Capta_Teste.Customer.Api.Data.ValueObject;

namespace Capta_Teste.Customer.Api.Repository.Interface
{
    public interface ICustomerTypeRepository
    {
        Task<IEnumerable<CustomerTypeVO>> FindAll();
    }
}
