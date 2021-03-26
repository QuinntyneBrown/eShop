using eShop.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace eShop.Api.Interfaces
{
    public interface IEShopDbContext
    {
        DbSet<User> Users { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<CatalogItem> CatalogItems { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Basket> Baskets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
