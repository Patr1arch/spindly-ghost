public class NoDiscount : IDiscount
{
    public decimal Apply(decimal amount)
    {
        return amount;
    }
}
