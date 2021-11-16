using System;

namespace ECommerce.Models
{
    public class OrderProduct
    {
        public Guid OrderId { get; }
        public string ProductId { get; }
        public int ProductQuantity { get; }
        
        // EF relations
        public virtual Product? Product { get; private set; }
        public virtual Order? Order { get; private set; }

        public OrderProduct(Guid orderId, string productId, int productQuantity)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductQuantity = productQuantity;
        }
    }
}