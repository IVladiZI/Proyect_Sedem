using Blazored.LocalStorage;
using Infraestructura.Abstract;
using Infraestructura.Models.QrPayment;
using System;
using System.Net.Http;
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

        public Task<ResponseEntity<T>> PostAsync<T>(string pControlador, QrPaymentRequest qrPaymentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
