using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Checkout
    {
        public double CalculateTotal(Cart cart, Discount discount)
        {
            return cart.GetProducts().Sum(p => discount.Apply(p.Price));
        }
    }
}
