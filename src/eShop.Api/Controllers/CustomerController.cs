using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{customerId}", Name = "GetCustomerByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomerById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCustomerById.Response>> GetById([FromRoute] GetCustomerById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Customer == null)
            {
                return new NotFoundObjectResult(request.CustomerId);
            }

            return response;
        }
    }
}
