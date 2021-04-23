using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextContentController
    {
        private readonly IMediator _mediator;

        public TextContentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{textContentId}", Name = "GetTextContentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTextContentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTextContentById.Response>> GetById([FromRoute] GetTextContentById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.TextContent == null)
            {
                return new NotFoundObjectResult(request.TextContentId);
            }

            return response;
        }

        [HttpGet(Name = "GetTextContentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTextContents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTextContents.Response>> Get()
            => await _mediator.Send(new GetTextContents.Request());

        [HttpPost(Name = "CreateTextContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTextContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTextContent.Response>> Create([FromBody] CreateTextContent.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTextContentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTextContentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTextContentsPage.Response>> Page([FromRoute] GetTextContentsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTextContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTextContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTextContent.Response>> Update([FromBody] UpdateTextContent.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{textContentId}", Name = "RemoveTextContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTextContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTextContent.Response>> Remove([FromRoute] RemoveTextContent.Request request)
            => await _mediator.Send(request);

    }
}
