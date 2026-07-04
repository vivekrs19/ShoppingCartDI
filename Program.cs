using Microsoft.Extensions.DependencyInjection;
using ShoppingCart;
using ShoppingCart.PaymentProcessors;

namespace SolidShoppingCartDI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<Cart>()
                .AddSingleton<CartPrinter>()
                .AddSingleton<Checkout>()
                .AddSingleton<Discount>(new PercentageDiscount(0.10)) // 10% discount
                .AddSingleton<IPaymentProcessor, CreditCardProcessor>() // Inject CreditCardProcessor
                .AddSingleton<OrderService>()
                .BuildServiceProvider();

            // Resolve services
            var cart = serviceProvider.GetService<Cart>();
            var printer = serviceProvider.GetService<CartPrinter>();
            var checkout = serviceProvider.GetService<Checkout>();
            var discount = serviceProvider.GetService<Discount>();
            var orderService = serviceProvider.GetService<OrderService>();

            // Add products
            cart.AddProduct(new Product { Name = "Green Tea", Price = 100 });
            cart.AddProduct(new Product { Name = "Coffee", Price = 200 });

            // Print cart
            printer.Print(cart);

            // Calculate total
            var total = checkout.CalculateTotal(cart, discount);
            Console.WriteLine($"Total after discount: {total:C}");

            // Place order
            orderService.PlaceOrder(cart, discount);

            Console.WriteLine("\nOrder placed successfully with DI!");
        }
    }
}
