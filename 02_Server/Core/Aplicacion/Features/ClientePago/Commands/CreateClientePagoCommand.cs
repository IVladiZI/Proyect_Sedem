using Aplicacion.DTOs.Cliente;
using Aplicacion.Features.Cliente.Commands;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Facturacion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.ClientePago.Commands
{
    public class CreateClientePagoCommand : IRequest<Response<int>>
    {
        public FcClientePagoDto fcClientePagoDto { get; set; }
    }
    public class CreateClientePagoCommandHandler : IRequestHandler<CreateClientePagoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<FcClientePago> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateClientePagoCommandHandler(IRepositoryAsync<FcClientePago> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClientePagoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<FcClientePago>(request.fcClientePagoDto);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdfcCliente);
        }


    }
}
