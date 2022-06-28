using AutoMapper;
using Capta_Teste.Customer.Api.Data.ValueObject;
using Capta_Teste.Customer.Api.Model.Context;
using Capta_Teste.Customer.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Capta_Teste.Customer.Api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        SqlServerContext _context;
        IMapper _mapper;

        public CustomerRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerVO>> FindAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<IEnumerable<CustomerVO>>(customers);
        }

        public async Task<CustomerVO> FindById(long id)
        {
            var customer = await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CustomerVO>(customer);
        }

        public async Task<CustomerVO> FindByCpf(string cpf)
        {
            var customer = await _context.Customers.Where(x => x.Cpf.Equals(cpf)).FirstOrDefaultAsync();
            return _mapper.Map<CustomerVO>(customer);
        }

        public async Task<CustomerVO> FindByName(string name)
        {

            var customer = await _context.Customers.Where(x => x.CustomerName.Contains(name)).FirstOrDefaultAsync();
            return _mapper.Map<CustomerVO>(customer);
        }

        public async Task<CustomerVO> Create(CustomerVO vo)
        {
            Model.Customer customer = _mapper.Map<Model.Customer>(vo);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerVO>(customer);
        }

        public async Task<CustomerVO> Update(CustomerVO vo)
        {
            Model.Customer customer = _mapper.Map<Model.Customer>(vo);
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerVO>(customer);
        }

        public async Task<bool> Delete(long id)
        {
            var customer = await _context.Customers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
