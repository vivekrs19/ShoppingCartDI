using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class CartPrinter
    {
        public void Print(Cart cart)
        {
            Console.WriteLine("Cart Contents:");
            foreach (var product in cart.GetProducts())
                Console.WriteLine($"{product.Name} - {product.Price:C}");
        }
    }
}
