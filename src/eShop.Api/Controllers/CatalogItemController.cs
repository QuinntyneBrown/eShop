using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogItemController
    {
        private readonly IMediator _mediator;

        public CatalogItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{catalogItemId}", Name = "GetCatalogItemByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCatalogItemById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCatalogItemById.Response>> GetById([FromRoute]GetCatalogItemById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.CatalogItem == null)
            {
                return new NotFoundObjectResult(request.CatalogItemId);
            }
        
            return response;
        }
        
    }
}
