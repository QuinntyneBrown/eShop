using eShop.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Api.Models
{
    public class Basket: BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid CustomerId { get; private set; }
        public List<BasketItem> BasketItems { get; private set; } = new List<BasketItem>();

        public Basket() { }

        public Basket(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Basket AddItem(Guid catalogItemId, decimal price, int quantity = 1)
        {
            if (!BasketItems.Any(i => i.CatalogItemId == catalogItemId))
            {
                BasketItems.Add(new BasketItem(catalogItemId, quantity, price));
                return this;
            }
            
            var existingItem = BasketItems.FirstOrDefault(i => i.CatalogItemId == catalogItemId);

            existingItem.AddQuantity(quantity);

            return this;
        }

        public Basket SetCustomerId(Guid customerId)
        {
            CustomerId = customerId;
            return this;
        }

        public void RemoveEmptyItems()
        {
            BasketItems.RemoveAll(i => i.Quantity == 0);
        }
    }
}
