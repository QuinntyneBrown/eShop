using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DigitalAssetController
    {
        private readonly IMediator _mediator;

        public DigitalAssetController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{digitalAssetId}", Name = "GetDigitalAssetByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetDigitalAssetById.Response>> GetById([FromRoute] GetDigitalAssetById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
            {
                return new NotFoundObjectResult(request.DigitalAssetId);
            }

            return response;
        }

        [HttpGet("range")]
        public async Task<ActionResult<GetDigitalAssetsByIds.Response>> GetByIds([FromQuery] GetDigitalAssetsByIds.Request request)
            => await _mediator.Send(request);

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAsset.Response>> Save()
            => await _mediator.Send(new UploadDigitalAsset.Request());

        [AllowAnonymous]
        [HttpGet("serve/{digitalAssetId}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Serve([FromRoute] GetDigitalAssetById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
                return new NotFoundObjectResult(null);

            return new FileContentResult(response.DigitalAsset.Bytes, response.DigitalAsset.ContentType);
        }

    }
}
