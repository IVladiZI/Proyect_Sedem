using Aplicacion.DTOs.Qr;
using Aplicacion.Interfaces;
using Aplicacion.Interfaces.Repositories;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Qr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Dominio.Entities.Qr.ResponseXml;

namespace Aplicacion.Features.Qr.Commands
{
    public class CreateQrCommand : IRequest<Response<string>>
    {
        public FcQrClienteDto FcQrClienteDto { get; set; }
        
    }
    public class CreateQrCommandHandler : IRequestHandler<CreateQrCommand, Response<string>>
    {
        private readonly IRepositoryAsync<FcQrCliente> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly IPaymentQr _paymentQr;

        public CreateQrCommandHandler(IRepositoryAsync<FcQrCliente> repositoryAsync, IMapper mapper, IPaymentQr paymentQr)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _paymentQr = paymentQr;
        }

        public async Task<Response<string>> Handle(CreateQrCommand request, CancellationToken cancellationToken)
        {
            try
            {
                FcQrCliente qrCliente = _mapper.Map<FcQrCliente>(request.FcQrClienteDto);
                qrCliente.QrEstado = "Pendiente";
                var data = await _repositoryAsync.AddAsync(qrCliente);

                var qrPendiente = await _repositoryAsync.GetByIdAsync(data.IdQrCliente);

                if (qrPendiente == null)
                    throw new KeyNotFoundException("Registro no encontrado");

                qrPendiente.IdQrCliente = qrPendiente.IdQrCliente;
                qrPendiente.QrDescripcion = $"{qrPendiente.IdQrCliente}_{qrPendiente.IdfcCliente}";
                Signature signature = _paymentQr.GenerateQr(qrCliente);
                qrPendiente.QrMensaje = signature.Object.Response.ResponseHeader.Message;

                if (signature.Object.Response.ResponseHeader.ResultCode != "0000")
                {
                    await _repositoryAsync.UpdateAsync(qrPendiente);
                    return new Response<string>(signature.Object.Response.ResponseHeader.Message);
                }

                qrPendiente.IdQrGenerado = signature.Object.Response.ResponseData.IdQr;
                qrPendiente.QrExpiracion = signature.Object.Response.ResponseHeader.Expiration;
                await _repositoryAsync.UpdateAsync(qrPendiente);

                return new Response<string>(signature.Object.Response.ResponseData.DataQR, signature.Object.Response.ResponseHeader.Message);

            }
            catch (Exception e)
            {

                throw e;
            }
            
        }


    }
}
