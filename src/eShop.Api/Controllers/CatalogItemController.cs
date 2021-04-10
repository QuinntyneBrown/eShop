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
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCatalogItemById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCatalogItemById.Response>> GetById([FromRoute]GetCatalogItemById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.CatalogItem == null)
            {
                return new NotFoundObjectResult(request.CatalogItemId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetCatalogItemsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCatalogItems.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCatalogItems.Response>> Get()
            => await _mediator.Send(new GetCatalogItems.Request());
        
        [HttpPost(Name = "CreateCatalogItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCatalogItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCatalogItem.Response>> Create([FromBody]CreateCatalogItem.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetCatalogItemsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCatalogItemsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCatalogItemsPage.Response>> Page([FromRoute]GetCatalogItemsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateCatalogItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCatalogItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCatalogItem.Response>> Update([FromBody]UpdateCatalogItem.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{catalogItemId}", Name = "RemoveCatalogItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCatalogItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCatalogItem.Response>> Remove([FromRoute]RemoveCatalogItem.Request request)
            => await _mediator.Send(request);
        
    }
}
