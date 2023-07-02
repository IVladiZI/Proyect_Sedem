using Aplicacion.DTOs.Cliente;
using Aplicacion.DTOs.Qr;
using Aplicacion.Features.Cliente.Queries;
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

namespace Aplicacion.Features.Qr.Queries
{
    public class GetAllQrQuery : IRequest<Response<List<FcQrClienteDto>>>
    {
        public class GetAllQrQueryHandler : IRequestHandler<GetAllQrQuery, Response<List<FcQrClienteDto>>>
        {
            private readonly IRepositoryAsync<FcQrCliente> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllQrQueryHandler(IRepositoryAsync<FcQrCliente> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<FcQrClienteDto>>> Handle(GetAllQrQuery request, CancellationToken cancellationToken)
            {
                var _Qr = await _repositoryAsync.ListAsync();
                var _QrDto = _mapper.Map<List<FcQrClienteDto>>(_Qr);
                return new Response<List<FcQrClienteDto>>(_QrDto);
            }
        }
    }    
}
