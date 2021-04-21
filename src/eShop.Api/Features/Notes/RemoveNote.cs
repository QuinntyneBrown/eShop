using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class RemoveNote
    {
        public class Request: IRequest<Response>
        {
            public Guid NoteId { get; set; }
        }

        public class Response: ResponseBase
        {
            public NoteDto Note { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var note = await _context.Notes.SingleAsync(x => x.NoteId == request.NoteId);
                
                _context.Notes.Remove(note);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Note = note.ToDto()
                };
            }
            
        }
    }
}
