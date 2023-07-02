using Infraestructura.Abstract;
using System.Threading.Tasks;

namespace Infraestructura.Services
{
    public interface IManagerQrPayment
    {
        Task<ResponseEntity<T>> PostAsync<T>(string pControlador, object parametros);
    }
}
