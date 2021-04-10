using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace eShop.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{basketId}", Name = "GetBasketByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBasketById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBasketById.Response>> GetById([FromRoute]GetBasketById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Basket == null)
            {
                return new NotFoundObjectResult(request.BasketId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetBasketsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBaskets.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBaskets.Response>> Get()
            => await _mediator.Send(new GetBaskets.Request());
        
        [HttpPost(Name = "CreateBasketRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBasket.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBasket.Response>> Create([FromBody]CreateBasket.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetBasketsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBasketsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBasketsPage.Response>> Page([FromRoute]GetBasketsPage.Request request)
            => await _mediator.Send(request);
        
/*        [HttpPut(Name = "UpdateBasketRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBasket.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBasket.Response>> Update([FromBody]UpdateBasket.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{basketId}", Name = "RemoveBasketRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBasket.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBasket.Response>> Remove([FromRoute]RemoveBasket.Request request)
            => await _mediator.Send(request);*/
        
    }
}
