using Capta_Test.Customer.UI.Model;
using Capta_Test.Customer.UI.Services.IServices;
using Capta_Test.Customer.UI.Util;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Capta_Test.Customer.UI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Customer";

        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CustomerModel>> FindAll()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.Content.ReadAsAsync<List<CustomerModel>>();
        }

        public async Task<CustomerModel> FindById(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.Content.ReadAsAsync<CustomerModel>();
        }

        public async Task<CustomerModel> FindByCpf(string cpf)
        {
            var response = await _client.GetAsync($"{BasePath}/cpf/{cpf}");
            return await response.Content.ReadAsAsync<CustomerModel>();
        }
        public async Task<IEnumerable<CustomerModel>> FindByName(string name)
        {
            var response = await _client.GetAsync($"{BasePath}/name/{name}");
            return await response.Content.ReadAsAsync<List<CustomerModel>>();
        }
        public async Task<CustomerModel> Create(CustomerModel vo)
        {
            var response = await _client.PostAsJsonAsync(BasePath, vo);
            return await response.ReadContentAs<CustomerModel>();
        }

        public async Task<CustomerModel> Update(CustomerModel vo)
        {
            var response = await _client.PutAsJsonAsync(BasePath, vo);
            return await response.ReadContentAs<CustomerModel>();
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            return await response.Content.ReadAsAsync<bool>();
        }
    }
}
