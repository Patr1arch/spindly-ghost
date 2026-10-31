public class CashPaymentMethod : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        // Реализация оплаты наличкой
        Console.WriteLine($"Paid {amount:F2} by cash.");
    }
}
