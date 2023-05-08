using Infraestructura.Abstract;
using Infraestructura.Models.QrPayment;
using System.Threading.Tasks;

namespace Infraestructura.Services
{
    public interface IManagerQrPayment
    {
        Task<ResponseEntity<T>> PostAsync<T>(string pControlador, QrPaymentRequest qrPaymentRequest);
    }
}
