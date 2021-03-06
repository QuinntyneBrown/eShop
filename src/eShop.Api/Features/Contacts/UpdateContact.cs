using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class UpdateContact
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Contact).NotNull();
                RuleFor(request => request.Contact).SetValidator(new ContactValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ContactDto Contact { get; set; }
        }

        public class Response : ResponseBase
        {
            public ContactDto Contact { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var contact = await _context.Contacts.SingleAsync(x => x.ContactId == request.Contact.ContactId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Contact = contact.ToDto()
                };
            }

        }
    }
}
