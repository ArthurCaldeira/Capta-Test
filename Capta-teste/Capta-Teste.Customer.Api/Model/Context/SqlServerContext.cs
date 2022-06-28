using Microsoft.EntityFrameworkCore;

namespace Capta_Teste.Customer.Api.Model.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext()
        {

        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerStatus> CustomerStatus { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
    }
}
