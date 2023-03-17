﻿using Aplicacion.Features.Cliente.Commands;
using Aplicacion.Features.Cliente.Queries;
using Aplicacion.Features.Qr.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Qr
{
    [ApiVersion("1.0")]
    [Authorize]
    public class QrClienteController : BaseApiController
    {
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllQrQuery
            {

            }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /*
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var del = new DeleteClienteCommand { IdCliente = id };
            var res = await Mediator.Send(del);
            return Ok(res);
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.IdfcCliente)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }*/
    }
}
