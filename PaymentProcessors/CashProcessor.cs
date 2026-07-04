using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.PaymentProcessors
{
    public class CashProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount) =>
            Console.WriteLine($"Paid {amount:C} in cash.");
    }
}
