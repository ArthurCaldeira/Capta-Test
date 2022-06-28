using Capta_Teste.Customer.Api.Data.ValueObject;
using Capta_Teste.Customer.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capta_Teste.Customer.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerStatusController : ControllerBase
    {
        ICustomerStatusRepository _repository;

        public CustomerStatusController(ICustomerStatusRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerStatusVO>>> Get()
        {
            var customerStatus = await _repository.FindAll();
            return Ok(customerStatus);
        }

    }
}
