using Capta_Teste.Customer.Api.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capta_Teste.Customer.Api.Model
{
    [Table("customer")]
    public class Customer: BaseEntity
    {
        [Column("CustomerName")]
        public string CustomerName { get; set; }
        
        [Column("Cpf")]
        public string Cpf { get; set; }

        [Column("CustomerTypeId")]
        public int CustomerTypeId { get; set; }
        
        [Column("Gender")]
        [MaxLength(1)]
        public string Gender { get; set; }
        
        [Column("CustomerStatusId")]
        public int CustomerStatusId { get; set; }
    }
}
