using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class NoteExtensions
    {
        public static NoteDto ToDto(this Note note)
        {
            return new()
            {
                NoteId = note.NoteId
            };
        }

    }
}
