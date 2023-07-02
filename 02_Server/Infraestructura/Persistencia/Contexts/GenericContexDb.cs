
using Dominio.Entities;
using Dominio.Entities.Facturacion;
using Dominio.Entities.Qr;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Contexts
{
    public class GenericContexDb : DbContext
    {
        public GenericContexDb(DbContextOptions options) : base(options)
        {

        }

        //TODO: Agregar aqui DbSets de las entidades de dominio correspondiente al contexto de conexcion general.

        #region DbSets
        public DbSet<FcCliente> Cliente { get; set; }
        public DbSet<FcSucursal> Sucursal { get; set; }
        public DbSet<FcQrCliente> QrClientes { get; set; }
        public DbSet<FcClientePago> fcClientePagos { get; set; }
        #endregion

    }
}
