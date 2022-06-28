using Capta_Test.Customer.UI.Model;
using Capta_Test.Customer.UI.Services.IServices;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Capta_Test.Customer.UI.Services
{
    public class CustomerStatusService : ICustomerStatusService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/CustomerStatus";

        public CustomerStatusService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CustomerStatusModel>> Get()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.Content.ReadAsAsync<List<CustomerStatusModel>>();
        }
    }
}
