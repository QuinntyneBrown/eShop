using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetNoteById
    {
        public class Request : IRequest<Response>
        {
            public Guid NoteId { get; set; }
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
                return new()
                {
                    Note = (await _context.Notes.SingleOrDefaultAsync(x => x.NoteId == request.NoteId)).ToDto()
                };
            }

        }
    }
}
