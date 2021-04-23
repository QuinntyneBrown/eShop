using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class UpdateNote
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Note).NotNull();
                RuleFor(request => request.Note).SetValidator(new NoteValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public NoteDto Note { get; set; }
        }

        public class Response : ResponseBase
        {
            public NoteDto Note { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var note = await _context.Notes.SingleAsync(x => x.NoteId == request.Note.NoteId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Note = note.ToDto()
                };
            }

        }
    }
}
