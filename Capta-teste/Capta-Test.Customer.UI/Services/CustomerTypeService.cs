using Capta_Test.Customer.UI.Model;
using Capta_Test.Customer.UI.Services.IServices;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Capta_Test.Customer.UI.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/CustomerType";

        public CustomerTypeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CustomerTypeModel>> Get()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.Content.ReadAsAsync<List<CustomerTypeModel>>();
        }
    }
}
