using Aplicacion.Features.ClientePago.Commands;
using Aplicacion.Features.ClientePago.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.ClientePago
{
    [ApiVersion("1.0")]
    [ApiController]
    public class FcClientePagoController : BaseApiController
    {
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllClientePagoQuery
            {

            }));
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateClientePagoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
