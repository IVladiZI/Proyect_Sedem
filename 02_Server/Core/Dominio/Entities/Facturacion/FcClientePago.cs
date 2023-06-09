﻿using Dominio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities.Facturacion
{
    [Table("fc_cliente_pago", Schema = "public")]
    public class FcClientePago : AuditableBaseEntity
    {
        [Key]
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
