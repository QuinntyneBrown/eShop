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
    public class CustomizationController
    {
        private readonly IMediator _mediator;

        public CustomizationController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{customizationId}", Name = "GetCustomizationByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomizationById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomizationById.Response>> GetById([FromRoute] GetCustomizationById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Customization == null)
            {
                return new NotFoundObjectResult(request.CustomizationId);
            }

            return response;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetCustomizationsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomizations.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomizations.Response>> Get()
            => await _mediator.Send(new GetCustomizations.Request());

        [HttpPost(Name = "CreateCustomizationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCustomization.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCustomization.Response>> Create([FromBody] CreateCustomization.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetCustomizationsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomizationsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomizationsPage.Response>> Page([FromRoute] GetCustomizationsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateCustomizationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCustomization.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCustomization.Response>> Update([FromBody] UpdateCustomization.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{customizationId}", Name = "RemoveCustomizationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCustomization.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCustomization.Response>> Remove([FromRoute] RemoveCustomization.Request request)
            => await _mediator.Send(request);

    }
}
