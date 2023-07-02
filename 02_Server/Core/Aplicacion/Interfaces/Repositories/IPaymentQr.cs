using Aplicacion.DTOs.Segurity;
using Dominio.Entities.Qr;
using System.Threading.Tasks;
using static Dominio.Entities.Qr.ResponseXml;

namespace Aplicacion.Interfaces.Repositories
{
    public interface IPaymentQr
    {
        Signature GenerateQr(FcQrCliente fcQrCliente);
    }
}
