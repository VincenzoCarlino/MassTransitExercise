using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Models
{
    public class Order
    {
        public Guid Id { get; }
        public string User { get; }
        public string Address { get; }
        public string Status { get; }
        public decimal TotalPrice { get; }
        
        // EF Relations
        public virtual ICollection<OrderProduct>? OrderProducts { get; private set; }

        public Order(Guid id, string user, string address, string status, decimal totalPrice)
        {
            Id = id;
            User = user;
            Address = address;
            Status = status;
            TotalPrice = totalPrice;
        }

        public void SetProducts(IEnumerable<(Product, int)> products)
        {
            OrderProducts = new List<OrderProduct>();
            foreach (var product in products.ToList())
            {
                OrderProducts.Add(new OrderProduct(Id, product.Item1.Id, product.Item2));
            }
        }
    }
}