using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class CreateNote
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
                var note = new Note();

                _context.Notes.Add(note);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Note = note.ToDto()
                };
            }

        }
    }
}
