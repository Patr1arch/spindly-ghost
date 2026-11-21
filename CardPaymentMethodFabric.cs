public class CardPaymentMethodFabric : AbstractPaymentMethodFabric
{
    public override IPaymentMethod Create()
    {
        return new CardPaymentMethod(
            "http://example.com",
            "123"
        );
    }
}
