using Capta_Teste.Customer.Api.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capta_Teste.Customer.Api.Model
{
    [Table("customer_type")]
    public class CustomerType: BaseEntity
    {
        [Column("CustomerType")]
        public string Type { get; set; }
    }
}
