using Dominio.Entities.Qr;
using static Dominio.Entities.Qr.ResponseXml;

namespace Aplicacion.Interfaces.Repositories
{
    public interface IPaymentQr
    {
        Signature GenerateQr(FcQrCliente fcQrCliente);
    }
}
