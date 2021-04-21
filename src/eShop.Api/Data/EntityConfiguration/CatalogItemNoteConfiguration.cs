using eShop.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Api.Data
{
    public class CatalogItemNoteConfiguration: IEntityTypeConfiguration<CatalogItemNote>
    {
        public void Configure(EntityTypeBuilder<CatalogItemNote> builder)
        {
            builder.HasKey(x => new { x.CatalogItemId, x.NoteId });   
        }        
    }
}
