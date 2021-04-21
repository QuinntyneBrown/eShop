using System;

namespace eShop.Api.Models
{
    public class Note
    {
        public Guid NoteId { get; private set; }
        public string Body { get; private set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime? Deleted { get; private set; }
    }
}
