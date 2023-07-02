using Aplicacion.Features.Cliente.Queries;
using Aplicacion.Features.Qr.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Qr
{
    [ApiVersion("1.0")]
    [Authorize]
    public class FcQrClienteController : BaseApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateQrCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
