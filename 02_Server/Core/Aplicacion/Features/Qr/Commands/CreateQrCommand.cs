using Aplicacion.DTOs.Qr;
using Aplicacion.Interfaces;
using Aplicacion.Services.MethodsPayment;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Qr;
using MediatR;
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
        public CreateQrCommandHandler(IRepositoryAsync<FcQrCliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateQrCommand request, CancellationToken cancellationToken)
        {
            FcQrCliente qrCliente = _mapper.Map<FcQrCliente>(request.FcQrClienteDto);
            
            PaymentQr paymentQr = new();
            Signature signature = paymentQr.GenerateQr(qrCliente);

            if (signature.Object.Response.ResponseHeader.ResultCode != "0000")
                return new Response<string>(signature.Object.Response.ResponseHeader.Message);
            return new Response<string>(signature.Object.Response.ResponseData.DataQR, signature.Object.Response.ResponseHeader.Message);
        }


    }
}
