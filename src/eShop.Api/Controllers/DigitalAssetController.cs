using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
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
        public async Task<ActionResult<GetDigitalAssetById.Response>> GetById([FromRoute]GetDigitalAssetById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.DigitalAsset == null)
            {
                return new NotFoundObjectResult(request.DigitalAssetId);
            }
        
            return response;
        }
        
    }
}
