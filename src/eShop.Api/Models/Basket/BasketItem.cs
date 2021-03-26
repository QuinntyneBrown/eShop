using Ardalis.GuardClauses;
using System;

namespace eShop.Api.Models
{
    public class BasketItem
    {
        public Guid BasketItemId { get; set; }
        public Guid BasketId { get; set; }
        public Guid CatalogItemId { get; init; }
        public int Quantity { get; private set; }
        public decimal Price { get; private init; }
        public BasketItem(Guid catalogItemId, int quantity, decimal price)
        {
            CatalogItemId = catalogItemId;
            Quantity = quantity;
            Price = price;
        }

        public BasketItem SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;

            return this;
        }

        public BasketItem AddQuantity(int quantity)
        {
            Quantity += quantity;
            return this;
        }
    }
}
