using System;

namespace Aplicacion.DTOs.Cliente
{
    public class FcClientePagoDto
    {
        public int IdQrCliente { get; set; }
        public int IdfcCliente { get; set; }
        public string IdQrGenerado { get; set; }
        public string QrGlosa { get; set; }
        public decimal QrMonto { get; set; }
        public DateTime? QrFechaPago { get; set; }
        public string QrEstado { get; set; }
        public string QrMensaje { get; set; }
        public DateTime? QrExpiracion { get; set; }
    }
}
