public class DecoratorLoggerPaymentMethod : IPaymentMethod
{
    private IPaymentMethod _inner;

    public DecoratorLoggerPaymentMethod(IPaymentMethod paymentMethod)
    {
        _inner = paymentMethod;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"[LOG] Start payment of amount {amount}");
        _inner.Pay(amount);
        Console.WriteLine($"[LOG] End payment of amount {amount}");
    } 
}
