using Aplicacion.Features.Qr.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Qr
{
    [ApiVersion("1.0")]
    [Authorize]
    public class QrClienteController : BaseApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GenerateQr(CreateQrCommand createQrCommand)
        {
            return Ok(await Mediator.Send(createQrCommand));
        }
    }
}
