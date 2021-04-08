using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{orderId}", Name = "GetOrderByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrderById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetOrderById.Response>> GetById([FromRoute] GetOrderById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Order == null)
            {
                return new NotFoundObjectResult(request.OrderId);
            }

            return response;
        }

        [HttpPut("checkout", Name = "CheckoutOrderRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CheckoutOrder.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CheckoutOrder.Response>> Checkout([FromBody] CheckoutOrder.Request request)
            => await _mediator.Send(request);

    }
}
