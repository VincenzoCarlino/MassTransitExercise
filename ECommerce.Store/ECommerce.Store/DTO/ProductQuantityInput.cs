namespace ECommerce.Store.DTO
{
    public class ProductQuantityInput
    {
        public int Quantity { get; }

        public ProductQuantityInput(int quantity)
        {
            Quantity = quantity;
        }
    }
}