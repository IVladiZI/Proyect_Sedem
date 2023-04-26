using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Cliente
{
    public class FcClientePagoDto
    {
        public int IdfcClientePago { get; set; }
        //[ForeignKey("IdfcCliente")]
        public int IdfcCliente { get; set; }
        public string Detalle { get; set; }
        public string Glosa { get; set; }
        public decimal Monto { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; }
    }
}
