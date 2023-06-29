using Aplicacion.DTOs.Segurity;
using Dominio.Entities.Qr;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositories
{
    public interface IPaymentQr
    {
        string GenerateQr(string fcQrGenerate);
    }
}
