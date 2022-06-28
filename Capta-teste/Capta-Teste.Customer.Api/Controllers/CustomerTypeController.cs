using Capta_Teste.Customer.Api.Data.ValueObject;
using Capta_Teste.Customer.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capta_Teste.Customer.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        ICustomerTypeRepository _repository;

        public CustomerTypeController(ICustomerTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerTypeVO>>> Get()
        {
            var customerType = await _repository.FindAll();
            return Ok(customerType);
        }
    }
}
