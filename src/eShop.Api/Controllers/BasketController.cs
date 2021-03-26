using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{basketId}", Name = "GetBasketByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBasketById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetBasketById.Response>> GetById([FromRoute]GetBasketById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Basket == null)
            {
                return new NotFoundObjectResult(request.BasketId);
            }
        
            return response;
        }
        
    }
}
