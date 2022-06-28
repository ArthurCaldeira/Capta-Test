using AutoMapper;
using Capta_Teste.Customer.Api.Data.ValueObject;
using Capta_Teste.Customer.Api.Model.Context;
using Capta_Teste.Customer.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Capta_Teste.Customer.Api.Repository
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        SqlServerContext _context;
        IMapper _mapper;

        public CustomerTypeRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerTypeVO>> FindAll()
        {
            var customTypes = await _context.CustomerType.ToListAsync();
            return _mapper.Map<IEnumerable<CustomerTypeVO>>(customTypes);
        }
    }
}
