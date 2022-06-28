using Capta_Test.Customer.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capta_Test.Customer.UI.Services.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> FindAll();
        Task<CustomerModel> FindById(int id);
        Task<CustomerModel> FindByCpf(string cpf);
        Task<IEnumerable<CustomerModel>> FindByName(string name);
        Task<CustomerModel> Create(CustomerModel vo);
        Task<CustomerModel> Update(CustomerModel vo);
        Task<bool> Delete(int id);
    }
}
