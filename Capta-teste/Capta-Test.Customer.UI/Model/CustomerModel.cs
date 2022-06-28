using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capta_Test.Customer.UI.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Cpf { get; set; }
        public int CustomerTypeId { get; set; }
        public string Gender { get; set; }
        public int CustomerStatusId { get; set; }
    }
}
