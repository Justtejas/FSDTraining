namespace CreationalPatterns.StructuralAdapterPattern
{
    internal class SAPDemo
    {
        public void SAPDemoMethod()
        {
            OldPaymentService oldPaymentService = new();
            IPaymentProcessor paymentProcessor = new PaymentAdapter(oldPaymentService);
            Client client = new(paymentProcessor);
            client.MakePayment(8099.09m);
        }
    }
}
