using System;

namespace Aplicacion.DTOs.Qr
{
    public class QrClienteDto
    {
        public int IdqrCliente { get; set; }
        public int IdfcCliente { get; set; }
        public string QrGlosa { get; set; }
        public decimal QrMonto { get; set; }
        public DateTime? QrExpiracion { get; set; }
        public string QrEstado { get; set; }
    }
}
