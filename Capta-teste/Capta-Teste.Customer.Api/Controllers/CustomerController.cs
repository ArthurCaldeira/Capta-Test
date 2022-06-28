using Capta_Teste.Customer.Api.Data.ValueObject;
using Capta_Teste.Customer.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Capta_Teste.Customer.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerVO>>> FindAll()
        {
            var customers = await _repository.FindAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerVO>> FindById(int id)
        {
            var customer = await _repository.FindById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<CustomerVO>> FindByCpf(string cpf)
        {
            var customer = await _repository.FindByCpf(cpf);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<CustomerVO>>> FindByName(string name)
        {
            var customer = await _repository.FindByName(name);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerVO>> Post(CustomerVO vo)
        {
            if (vo == null) return BadRequest();
            var customer = await _repository.Create(vo);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<CustomerVO>> Put(CustomerVO vo)
        {
            if (vo == null) return BadRequest();
            var customer = await _repository.Update(vo);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
