using eShop.Api.Models;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Data
{
    public class EShopDbContext: DbContext, IEShopDbContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<Order> Orders { get; private set; }
        public DbSet<OrderItem> OrderItems { get; private set; }
        public DbSet<CatalogItem> CatalogItems { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Basket> Baskets { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<Contact> Contacts { get; private set; }
        public DbSet<Customization> Customizations { get; private set; }
        public DbSet<Content> Contents { get; private set; }
        public DbSet<HtmlContent> HtmlContents { get; private set; }
        public DbSet<ImageContent> ImageContents { get; private set; }
        public DbSet<TextContent> TextContents { get; private set; }
        public DbSet<Note> Notes { get; private set; }
        public EShopDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EShopDbContext).Assembly);
        }
        
    }
}
