public class CardPaymentMethod : IPaymentMethod
{
    private string _gateWayUrl;
    private string _token;

    public CardPaymentMethod(string gateWayUrl, string token)
    {
        _gateWayUrl = gateWayUrl;
        _token = token;
    }

    public void Pay(decimal amount)
    {
        // Реализация оплаты по карте
        Console.WriteLine($"Paid {amount:F2} by card.");
    }
}
