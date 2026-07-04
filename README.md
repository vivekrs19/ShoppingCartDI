# ShoppingCartDI
| Principle | Definition | Example |
| --- | --- | --- |
| **S – Single Responsibility Principle (SRP)** | A class should have only one reason to change. Each class should focus on a single responsibility. | A ``UserRegistration`` class handles user registration, while an ``EmailSender`` class separately manages email notifications. |
| **O – Open/Closed Principle (OCP)** | Classes should be open for extension but closed for modification. You should add new functionality by extending, not altering existing code. | A ``Discount`` base class with subclasses like ``PercentageDiscount`` or ``NoDiscount`` instead of editing the original class. |
| **L – Liskov Substitution Principle (LSP)** | Subclasses should be substitutable for their base classes without breaking functionality. | A ``Sparrow`` class can replace a ``Bird`` class seamlessly, but an ``Ostrich`` that throws exceptions when asked to fly violates LSP. |
| **I – Interface Segregation Principle (ISP)** | Clients should not be forced to depend on interfaces they don’t use. | Instead of one large interface, split into smaller ones like ``IPrinter`` and ``IScanner``. A ``SimplePrinter`` only implements ``IPrinter``. |
| **D – Dependency Inversion Principle (DIP)** | Depend on abstractions, not concrete implementations. High-level modules shouldn’t rely on low-level modules. | A ``Notification`` class depends on an ``IMessageService`` interface, which can be implemented by ``EmailService`` or ``SMSService``. |




Why SOLID Matters

Maintainability: Easier to update without breaking unrelated code.

Scalability: New features can be added by extending, not modifying.

Testability: Smaller, focused classes are easier to test.

Flexibility: Encourages loose coupling and modular design.

Common Pitfalls
SRP Violation: Putting database logic, business rules, and UI handling in one class.

OCP Violation: Editing existing classes instead of extending them.

LSP Violation: Subclasses throwing exceptions for base class methods they can’t support.

ISP Violation: Large interfaces forcing classes to implement unused methods.

DIP Violation: Hardcoding dependencies instead of injecting abstractions.


1. Single Responsibility Principle (SRP)
public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

public class Cart
{
    private readonly List<Product> _products = new List<Product>();

    public void AddProduct(Product product) => _products.Add(product);
    public IEnumerable<Product> GetProducts() => _products;
}

public class CartPrinter
{
    public void Print(Cart cart)
    {
        foreach (var product in cart.GetProducts())
            Console.WriteLine($"{product.Name} - {product.Price:C}");
    }
}

- Cart manages products.

- CartPrinter handles display.

- Each class has one reason to change.



2. Open/Closed Principle (OCP)

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

- New discount types can be added by extending Discount.

- Existing code remains untouched.



3. Liskov Substitution Principle (LSP)

public class Checkout
{
    public double CalculateTotal(Cart cart, Discount discount)
    {
        return cart.GetProducts().Sum(p => discount.Apply(p.Price));
    }
}

- Any Discount subclass (NoDiscount, PercentageDiscount, etc.) can be substituted without breaking Checkout.



4. Interface Segregation Principle (ISP)

public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

public interface IRefundProcessor
{
    void ProcessRefund(double amount);
}

public class CreditCardProcessor : IPaymentProcessor, IRefundProcessor
{
    public void ProcessPayment(double amount) => Console.WriteLine($"Paid {amount:C} by credit card.");
    public void ProcessRefund(double amount) => Console.WriteLine($"Refunded {amount:C} to credit card.");
}

public class CashProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount) => Console.WriteLine($"Paid {amount:C} in cash.");
}

- CashProcessor doesn’t need refund logic, so it only implements IPaymentProcessor.



5. Dependency Inversion Principle (DIP)

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

- OrderService depends on IPaymentProcessor abstraction.

- You can inject CreditCardProcessor, CashProcessor, or any future payment method.


How It All Fits Together
SRP → Classes are focused (Cart, CartPrinter).

OCP → Discounts are extensible.

LSP → All discounts behave consistently.

ISP → Payment processors only implement what they need.

DIP → OrderService is flexible with payment methods.