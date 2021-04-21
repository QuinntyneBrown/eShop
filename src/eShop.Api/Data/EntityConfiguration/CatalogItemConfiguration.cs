using eShop.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Api.Data
{
    public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.HasMany(x => x.Notes)
                            .WithMany(x => x.CatalogItems)
                            .UsingEntity<CatalogItemNote>(
                                x => x.HasOne(x => x.Note)
                                .WithMany().HasForeignKey(x => x.NoteId),
                                x => x.HasOne(x => x.CatalogItem)
                               .WithMany().HasForeignKey(x => x.CatalogItemId));
        }

    }
}
