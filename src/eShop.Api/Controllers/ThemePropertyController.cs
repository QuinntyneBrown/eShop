using System.Net;
using System.Threading.Tasks;
using eShop.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemePropertyController
    {
        private readonly IMediator _mediator;

        public ThemePropertyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{themePropertyId}", Name = "GetThemePropertyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetThemePropertyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetThemePropertyById.Response>> GetById([FromRoute]GetThemePropertyById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.ThemeProperty == null)
            {
                return new NotFoundObjectResult(request.ThemePropertyId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetThemePropertiesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetThemeProperties.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetThemeProperties.Response>> Get()
            => await _mediator.Send(new GetThemeProperties.Request());
        
        [HttpPost(Name = "CreateThemePropertyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateThemeProperty.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateThemeProperty.Response>> Create([FromBody]CreateThemeProperty.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetThemePropertiesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetThemePropertiesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetThemePropertiesPage.Response>> Page([FromRoute]GetThemePropertiesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateThemePropertyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateThemeProperty.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateThemeProperty.Response>> Update([FromBody]UpdateThemeProperty.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{themePropertyId}", Name = "RemoveThemePropertyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveThemeProperty.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveThemeProperty.Response>> Remove([FromRoute]RemoveThemeProperty.Request request)
            => await _mediator.Send(request);
        
    }
}
