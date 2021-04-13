using eShop.Api.Core;
using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class UpdateUser
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.User).NotNull();
                RuleFor(request => request.User).SetValidator(new UserValidator());
            }
        }

        public class Request : IRequest<Response> { 
            public UserDto User { get; set; }        
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
            
                var user = await _context.Users.FindAsync(request.User.UserId);

                user.Username = request.User.Username;

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 
                    User = user.ToDto()
                };
            }
        }
    }
}
