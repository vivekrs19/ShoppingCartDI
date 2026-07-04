using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public abstract class Discount
    {
        public abstract double Apply(double price);
    }

    public class NoDiscount : Discount
    {
        public override double Apply(double price) => price;
    }

    public class PercentageDiscount : Discount
    {
        private readonly double _percent;
        public PercentageDiscount(double percent) => _percent = percent;
        public override double Apply(double price) => price * (1 - _percent);
    }
}
