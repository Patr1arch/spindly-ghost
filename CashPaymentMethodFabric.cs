public class CashPaymentMethodFabric : AbstractPaymentMethodFabric
{
    public override IPaymentMethod Create()
    {
        return new CashPaymentMethod(false);
    }
}
