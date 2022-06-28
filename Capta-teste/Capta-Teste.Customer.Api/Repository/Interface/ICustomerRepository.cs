using Capta_Teste.Customer.Api.Data.ValueObject;

namespace Capta_Teste.Customer.Api.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerVO>> FindAll();
        Task<CustomerVO> FindById(long id);
        Task<CustomerVO> FindByCpf(string cpf);
        Task<CustomerVO> FindByName(string name);
        Task<CustomerVO> Create(CustomerVO vo);
        Task<CustomerVO> Update(CustomerVO vo);
        Task<bool> Delete(long id);
    }
}
