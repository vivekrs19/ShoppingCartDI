using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.PaymentProcessors
{
    public class CreditCardProcessor : IPaymentProcessor, IRefundProcessor
    {
        public void ProcessPayment(double amount) =>
            Console.WriteLine($"Paid {amount:C} by credit card.");

        public void ProcessRefund(double amount) =>
            Console.WriteLine($"Refunded {amount:C} to credit card.");
    }
}
