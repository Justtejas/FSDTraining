using CreationalPatterns.FactoryPattern;

namespace CreationalPatterns.StructuralAdapterPattern
{
    public class OldPaymentService
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"Proccessing payments of {amount} using OldPayment Service");
        }
    }

    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class PaymentAdapter : IPaymentProcessor
    {
        private readonly OldPaymentService _service;
        public PaymentAdapter(OldPaymentService service)
        {
            _service = service;
        }

        public void ProcessPayment(decimal amount)
        {
            _service.MakePayment(amount);
        }
    }

    public class Client
    {
        private readonly IPaymentProcessor _paymentProcessor;
        public Client(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void MakePayment(decimal amount)
        {
            _paymentProcessor.ProcessPayment(amount);
        }
    }
}
