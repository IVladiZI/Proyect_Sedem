using Dominio.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities.Qr
{
    [Table("qr_cliente", Schema = "public")]
    public class FcQrCliente : AuditableBaseEntity
    {
        [Key]
        public long IdQrCliente { get; set; }
        public long IdfcCliente { get; set; }
        public string IdQrGenerado { get; set; }
        public string QrDescripcion { get; set; }
        public string QrGlosa { get; set; }
        public string QrMensaje { get; set; }
        public decimal QrMonto { get; set; }
        public DateTime? QrExpiracion { get; set; }
        public string QrEstado { get; set; }
        public DateTime? QrFechaPago { get; set; }
    }
}
