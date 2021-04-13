using eShop.Api.Core;
using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class RemoveUser
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.UserId).NotNull().NotEmpty();
            }
        }

        public class Request : IRequest<ResponseBase> { 
            public System.Guid UserId { get; set; }        
        }


        public class Handler : IRequestHandler<Request, ResponseBase>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context){
                _context = context;
            }

            public async Task<ResponseBase> Handle(Request request, CancellationToken cancellationToken) {
            
                var user = await _context.Users.FindAsync(request.UserId);

                _context.Users.Remove(user);

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 

                };
            }
        }
    }
}
