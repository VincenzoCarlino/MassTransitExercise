using System.Collections.Generic;

namespace ECommerce.DTO
{
    public class NewOrderInput
    {
        public string User { get; }
        public string Address { get; }
        public List<NewOrderProductInput> Products { get; }

        public NewOrderInput(string user, string address, List<NewOrderProductInput> products)
        {
            User = user;
            Address = address;
            Products = products;
        }
    }

    public class NewOrderProductInput
    {
        public string Id { get; }
        public int Quantity { get; }

        public NewOrderProductInput(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}