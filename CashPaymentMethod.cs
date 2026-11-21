public class CashPaymentMethod : IPaymentMethod
{
    private bool _isForeingCurrency;

    public CashPaymentMethod(bool isForeingCurrency)
    {
        _isForeingCurrency = isForeingCurrency;
    }

    public void Pay(decimal amount)
    {
        // Реализация оплаты наличкой
        Console.WriteLine($"Paid {amount:F2} by cash.");
    }
}
