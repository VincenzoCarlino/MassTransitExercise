using System.Collections;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Product
    {
        public string Id { get; }
        public string Name { get; }
        public string? Description { get; }
        public int AvailableQuantity { get; internal set; }
        public decimal Price { get; }
        
        // EF Relations
        public virtual ICollection<OrderProduct>? OrdersProduct { get; private set; }

        public Product(string id, string name, string? description, int availableQuantity, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            AvailableQuantity = availableQuantity;
            Price = price;
        }
    }
}