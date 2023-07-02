using Blazored.LocalStorage;
using Infraestructura.Abstract;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructura.Services
{
    public class ManagerQrPayment : IManagerQrPayment
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public ManagerQrPayment(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<ResponseEntity<T>> PostAsync<T>(string pControlador, object parametros)
        {
            var cliente = await GetCliente();
            HttpResponseMessage result = new();
            result = await cliente.PostAsJsonAsync(pControlador, parametros);

            if (result.IsSuccessStatusCode)
            {
                using var responseStream = await result.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ResponseEntity<T>>(responseStream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                data.State = data.Succeeded == true ? State.Success : State.Warning;
                return data;
            }
            else
            {
                var errorres = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ResponseEntity<T>>(errorres);
            }
        }
        private async Task<HttpClient> GetCliente()
        {
            var cliente = _httpClientFactory.CreateClient("Api");
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsStringAsync("KEYACCES"));
            return cliente;
        }
    }
}
