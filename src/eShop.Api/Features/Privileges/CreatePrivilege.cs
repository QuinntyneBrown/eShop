using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class CreatePrivilege
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Privilege).NotNull();
                RuleFor(request => request.Privilege).SetValidator(new PrivilegeValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public PrivilegeDto Privilege { get; set; }
        }

        public class Response : ResponseBase
        {
            public PrivilegeDto Privilege { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var privilege = new Privilege(default, null);

                _context.Privileges.Add(privilege);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Privilege = privilege.ToDto()
                };
            }

        }
    }
}
