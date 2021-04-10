using eShop.Api.Exceptions;
using System;
using System.Collections.Generic;

namespace eShop.Api.Models
{
    public class CatalogItem
    {
        public Guid CatalogItemId { get; set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public bool OnReOrder { get; set; }
        public List<CatalogItemImage> CatalogItemImages { get; set; } = new List<CatalogItemImage>();
        public int InventoryCount { get; set; } = 0;

        public CatalogItem(string name)
        {
            Name = name;
        }

        public CatalogItem() { }

        public CatalogItem UpdateName(string name)
        {
            Name = name;
            return this;
        }

        public CatalogItem AddStock(int quantity)
        {
            QuantityInStock += quantity;

            return this;
        }

        public CatalogItem RemoveStock(int quantity)
        {
            if (QuantityInStock == 0)
            {
                throw new DomainException();
            }

            if (quantity > QuantityInStock)
            {
                throw new DomainException();
            }

            QuantityInStock -= quantity;


            return this;
        }
    }
}
