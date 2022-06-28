using Capta_Teste.Customer.Api.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capta_Teste.Customer.Api.Model
{
    [Table("customer_status")]
    public class CustomerStatus: BaseEntity
    {
        [Column("CustomerStatus")]
        public string Status { get; set; }
    }
}
