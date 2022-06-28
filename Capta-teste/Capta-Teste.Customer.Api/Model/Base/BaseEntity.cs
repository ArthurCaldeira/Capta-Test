using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capta_Teste.Customer.Api.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
    }
}
