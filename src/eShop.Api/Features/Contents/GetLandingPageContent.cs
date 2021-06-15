using eShop.Api.Core;
using eShop.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class GetLandingPageContent
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public LandingPageContentDto LandingPageContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var caption = (await _context.TextContents.SingleOrDefaultAsync(x => x.Name == Constants.TextContents.LandingPageCaption)).ToDto();

                var about = (await _context.TextContents.SingleOrDefaultAsync(x => x.Name == Constants.TextContents.About)).ToDto();

                var catalogItems = _context.CatalogItems.Select(x => x.ToDto()).ToList();

                return new()
                {
                    LandingPageContent = new()
                    {
                        Caption = caption?.Value,
                        FeaturedCatalogItems = catalogItems,
                        About = about?.Value
                    }
                };
            }
        }
    }
}
