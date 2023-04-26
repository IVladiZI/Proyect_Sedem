using Aplicacion.DTOs.Cliente;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Facturacion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.ClientePago.Queries
{
    public class GetAllClientePagoQuery : IRequest<Response<List<FcClientePagoDto>>>
    {
        public class GetAllClientePagoQueryHandler : IRequestHandler<GetAllClientePagoQuery, Response<List<FcClientePagoDto>>>
        {
            private readonly IRepositoryAsync<FcClientePago> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllClientePagoQueryHandler(IRepositoryAsync<FcClientePago> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<FcClientePagoDto>>> Handle(GetAllClientePagoQuery request, CancellationToken cancellationToken)
            {
                var _ClientePago = await _repositoryAsync.ListAsync();
                var _ClientePagoDto = _mapper.Map<List<FcClientePagoDto>>(_ClientePago);
                return new Response<List<FcClientePagoDto>>(_ClientePagoDto);
            }
        }
    }
}
