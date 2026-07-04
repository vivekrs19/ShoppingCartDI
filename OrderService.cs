using ShoppingCart.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class OrderService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public OrderService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void PlaceOrder(Cart cart, Discount discount)
        {
            var total = cart.GetProducts().Sum(p => discount.Apply(p.Price));
            _paymentProcessor.ProcessPayment(total);
        }
    }
}
