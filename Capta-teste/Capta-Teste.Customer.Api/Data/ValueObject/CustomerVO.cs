namespace Capta_Teste.Customer.Api.Data.ValueObject
{
    public class CustomerVO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public string Cpf { get; set; }

        public int CustomerTypeId { get; set; }

        public string Gender { get; set; }

        public int CustomerStatusId { get; set; }
    }
}
