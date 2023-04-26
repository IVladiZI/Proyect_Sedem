using Aplicacion.DTOs.Qr;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Qr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Qr.Commands
{
    public class CreateQrCommand : IRequest<Response<int>>
    {
        public QrCliente QrCliente { get; set; }

    }

    public class CreateQrCommandHandler : IRequestHandler<CreateQrCommand, Response<int>>
    {
        private readonly IRepositoryAsync<QrCliente> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateQrCommandHandler(IRepositoryAsync<QrCliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQrCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<QrCliente>(request.QrCliente);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdfcCliente);
        }


    }
}
