using Dominio.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Dominio.Entities.Qr
{
    [Table("qr_cliente", Schema = "public")]
    public class FcQr : AuditableBaseEntity
    {
        [Key]
        public int IdqrCliente { get; set; }
        //[ForeignKey("IdfcCliente")]
        public int IdfcCliente { get; set; }
        public string QrGlosa { get; set; }
        public decimal QrMonto { get; set; }
        public DateTime? QrExpiracion { get; set; }
        public string QrEstado { get; set; }
    }
    public class FcQrGenerate
    {
        public int IdCliente { get; set; }
        public decimal Monto { get; set; }
        public string Glosa { get; set; }
    }
}
