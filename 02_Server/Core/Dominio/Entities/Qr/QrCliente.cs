using Dominio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities.Qr
{
    [Table("qr_cliente", Schema = "public")]
    public class QrCliente : AuditableBaseEntity
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
}
