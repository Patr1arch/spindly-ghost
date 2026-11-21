public class OrderItem
{
    private string _name;
    private decimal _price;
    private int _quantity;

    public OrderItem(string name, decimal price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public decimal GetPrice()
    {
        return _price;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}

public class OrderProcessor
{
    private readonly List<OrderItem> _items;
    private readonly IPaymentMethod _paymentMethod;
    private readonly IDiscount _discount;

    public OrderProcessor(IPaymentMethod paymentMethod, IDiscount discount)
    {
        _items = new();
        _paymentMethod = paymentMethod;
        _discount = discount;
    }

    public void AddItem(string name, decimal price, int quantity)
    {
        _items.Add(new OrderItem(name, price, quantity));
    }

    public decimal CalculateTotal()
    {
        decimal total = _items.Sum(
            item => item.GetPrice() * item.GetQuantity()
        );

        // decimal total = 0;
        // foreach (OrderItem item in _items)
        // {
        //     total += item.GetQuantity() * item.GetPrice();
        // }

        return _discount.Apply(total);
    }

    public void ProcessOrder(string notificationMethod)
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Order is empty.");
            return;
        }

        decimal total = CalculateTotal();

        _paymentMethod.Pay(total);

        // switch (paymentMethod.ToLower())
        // {
        //     case "card":
        //         Console.WriteLine($"Paid {total:F2} by card.");
        //         break;
        //     case "cash":
        //         Console.WriteLine($"Paid {total:F2} in cash.");
        //         break;
        //     case "mirPay":
        //         Console.WriteLine($"Paid {total:F2} in mir.");
        //         break;
        //     default:
        //         Console.WriteLine("Unsupported payment method.");
        //         return;
        // }

        string receipt = "Receipt\n";

        foreach (var item in _items)
        {
            receipt += $"{item.GetName()} x{item.GetQuantity()}: " +
                       $"{item.GetPrice() * item.GetQuantity():F2}\n";
        }

        receipt += $"Total: {total:F2}\n";
        Console.WriteLine(receipt);

        switch (notificationMethod.ToLower())
        {
            case "console":
                Console.WriteLine("Order confirmation sent to console.");
                break;
            case "email":
                Console.WriteLine("Order confirmation sent by email.");
                break;
            default:
                Console.WriteLine("Unsupported notification method.");
                break;
        }
    }
}

public class Program
{
    public static void Main()
    {
        AbstractPaymentMethodFabric paymentMethodFabric = new CashPaymentMethodFabric();
        // CardPaymentMethod cardPaymentMethod = new CardPaymentMethod("http://example.com", "123");
        // CashPaymentMethod cashPaymentMethod = new CashPaymentMethod(true);
        IPaymentMethod paymentMethod = paymentMethodFabric.Create();
        IDiscount discount = new NoDiscount();
        var order = new OrderProcessor(
            new DecoratorLoggerPaymentMethod(paymentMethod),
            discount
        );

        order.AddItem("Keyboard", 4500m, 3);
        order.AddItem("Mouse", 1500m, 2);

        Console.WriteLine($"Order total: {order.CalculateTotal():F2}");

        order.ProcessOrder("console");
    }
}
