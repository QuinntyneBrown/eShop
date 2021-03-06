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
    public class ContentController
    {
        private readonly IMediator _mediator;

        public ContentController(IMediator mediator)
            => _mediator = mediator;

        [AllowAnonymous]
        [HttpGet("landingpage", Name = "GetLandingPageContentRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetLandingPageContent.Response>> GetLandingPage([FromRoute] GetLandingPageContent.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.LandingPageContent == null)
            {
                return new NotFoundObjectResult("Landing Page");
            }

            return response;
        }

        [HttpGet("{contentId}", Name = "GetContentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContentById.Response>> GetById([FromRoute] GetContentById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Content == null)
            {
                return new NotFoundObjectResult(request.ContentId);
            }

            return response;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetContentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContents.Response>> Get()
            => await _mediator.Send(new GetContents.Request());

        [HttpPost(Name = "CreateContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateContent.Response>> Create([FromBody] CreateContent.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetContentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContentsPage.Response>> Page([FromRoute] GetContentsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateContent.Response>> Update([FromBody] UpdateContent.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{contentId}", Name = "RemoveContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveContent.Response>> Remove([FromRoute] RemoveContent.Request request)
            => await _mediator.Send(request);

    }
}
