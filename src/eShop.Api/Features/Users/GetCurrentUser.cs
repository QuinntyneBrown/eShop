using eShop.Api.Core;
using eShop.Api.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class GetCurrentUser
    {
        public class Request: IRequest<Response>
        {

        }

        public class Response: ResponseBase
        {
            public UserDto User { get; init; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public Handler(IEShopDbContext context, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var userId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(Constants.ClaimTypes.UserId).Value);

                var user = await _context.Users
                    .Include(x => x.Roles)
                    .SingleOrDefaultAsync(x => x.UserId == userId);

                return new()
                {
                    User = user.ToDto()
                };
            }
        }
    }
}
