namespace CreationalPatterns.FactoryPattern
{
    internal class FactoryPatternDemo
    {
        public void FactoryPatternDemoMethod()
        {
            try
            {
                string creditType;
                do
                {
                    Console.WriteLine("Enter the Card Type (or press q to exit):");
                    Console.WriteLine("Money Back");
                    Console.WriteLine("Visa");
                    Console.WriteLine("Titanium");
                    Console.Write("> ");
                    creditType = Console.ReadLine();
                    ICreditCard creditCard = CreditCardFactory.GetCreditCard(creditType);
                    if (creditCard != null)
                    {
                        Console.WriteLine($"Credit card type is: {creditCard.GetCardType()}");
                        Console.WriteLine($"Credit card credit limit is: {creditCard.GetCreditLimit()}");
                        Console.WriteLine($"Credit card annual charge is: {creditCard.GetAnnualCharge()}");
                    }
                } while (creditType != "q");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
