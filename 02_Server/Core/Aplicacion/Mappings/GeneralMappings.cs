
using Aplicacion.DTOs.Cliente;
using Aplicacion.DTOs.Qr;
using Aplicacion.DTOs.Segurity;
using Aplicacion.DTOs.Sucursal;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Facturacion;
using Dominio.Entities.Qr;
using Dominio.Entities.Seguridad;

namespace Aplicacion.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            //TODO: Agregar aqui el registro de mapeo para obtenion de consultas  direccion  EntidadDominio --> ModeloDto
            #region QueryDto
            CreateMap<SegvUsuario, SegUsuarioDto>();
            CreateMap<FcCliente, FcClienteDto>();
            CreateMap<FcClientePago, FcClientePagoDto>();
            CreateMap<FcSucursal, FcSucursalDto>();
            CreateMap<FcQr, QrClienteDto>();
            /**///**
            #endregion

            //TODO: Agregar aqui el registro de mapeo para ejecucion de comandos  direccion  ModeloDto --> EntidadDominio Ej. : CreateMap<ProductoDto, CapProducto>();
            #region Commands
            CreateMap<FcClienteDto, FcCliente>();
            CreateMap<FcClientePagoDto, FcClientePago>();
            CreateMap<FcSucursalDto, FcSucursal>();
            CreateMap<QrClienteDto, FcQr>();
            #endregion

        }
    }
}
