namespace ECommerce.Store.Models
{
    public class ProductQuantity
    {
        public string Id { get; }
        public int Quantity { get; internal set; }

        public ProductQuantity(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}