public class LargeOrderDiscount : IDiscount
{
    public decimal Apply(decimal amount)
    {
        return amount >= 10000 ? amount * 0.9m : amount;
    }
}
