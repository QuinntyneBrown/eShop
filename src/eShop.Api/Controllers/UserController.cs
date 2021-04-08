using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{userId}", Name = "GetUserByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUserById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetUserById.Response>> GetById([FromRoute] GetUserById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.User == null)
            {
                return new NotFoundObjectResult(request.UserId);
            }

            return response;
        }

    }
}
