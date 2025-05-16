using System.Collections.Generic;

namespace hoolsitebiydaalt.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserName { get; set; }  // эсвэл UserId

        public List<CartItem> CartItems { get; set; } = new();
    }

    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int Quantity { get; set; }
    }
}
