using eShop.Api.Core;
using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class UpdateUserAvatar
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.AvatarDigitalAssetId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public Guid UserId { get; set; }
            public Guid AvatarDigitalAssetId { get; set; }        
        }

        public class Response: ResponseBase
        {
            public UserDto User { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
            
                var user = await _context.Users.FindAsync(request.UserId);

                user.UpdateAvatar(request.AvatarDigitalAssetId);

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 
                    User = user.ToDto()
                };
            }
        }
    }
}
