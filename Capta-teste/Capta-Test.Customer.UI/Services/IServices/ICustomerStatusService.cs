using Capta_Test.Customer.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capta_Test.Customer.UI.Services.IServices
{
    public interface ICustomerStatusService
    {
        Task<IEnumerable<CustomerStatusModel>> Get();
    }
}
