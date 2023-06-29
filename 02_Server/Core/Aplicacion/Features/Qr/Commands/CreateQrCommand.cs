using Aplicacion.Interfaces;
using Aplicacion.Services.MethodsPayment;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Qr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Qr.Commands
{
    public class CreateQrCommand : IRequest<Response<string>>
    {
        public FcQrGenerate FcQrGenerate { get; set; }

    }

    public class CreateQrCommandHandler : IRequestHandler<CreateQrCommand, Response<string>>
    {
        //private readonly IRepositoryAsync<FcQr> _repositoryAsync;
        //private readonly IMapper _mapper;
        public CreateQrCommandHandler(IRepositoryAsync<FcQr> repositoryAsync, IMapper mapper)
        {
            //_repositoryAsync = repositoryAsync;
            //_mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateQrCommand request, CancellationToken cancellationToken)
        {
            PaymentQr paymentQr = new ();
            string content = $"{request.FcQrGenerate.IdCliente}|{request.FcQrGenerate.Monto}|{request.FcQrGenerate.Glosa}";
            paymentQr.GenerateQr(content);
            return new Response<string>(paymentQr.GenerateQr(content));
        }


    }
}
