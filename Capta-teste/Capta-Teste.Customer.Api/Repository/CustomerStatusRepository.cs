using AutoMapper;
using Capta_Teste.Customer.Api.Data.ValueObject;
using Capta_Teste.Customer.Api.Model.Context;
using Capta_Teste.Customer.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Capta_Teste.Customer.Api.Repository
{
    public class CustomerStatusRepository : ICustomerStatusRepository
    {
        SqlServerContext _context;
        IMapper _mapper;

        public CustomerStatusRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerStatusVO>> FindAll()
        {
            var customerStatus = await _context.CustomerStatus.ToListAsync();
            return _mapper.Map<IEnumerable<CustomerStatusVO>>(customerStatus);
        }
    }
}
