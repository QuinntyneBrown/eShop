using System;

namespace eShop.Api.Models
{
    public class CatalogItemNote
    {
        public Guid CatalogItemId { get; private set; }
        public Guid NoteId { get; private set; }
        public CatalogItem CatalogItem { get; private set; }
        public Note Note { get; private set; }
    }
}
