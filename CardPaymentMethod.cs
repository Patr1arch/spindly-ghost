public class CardPaymentMethod : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        // Реализация оплаты по карте
        Console.WriteLine($"Paid {amount:F2} by card.");
    }
}
