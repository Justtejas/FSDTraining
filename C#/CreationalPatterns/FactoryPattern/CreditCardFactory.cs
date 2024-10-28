namespace CreationalPatterns.FactoryPattern
{
    internal class CreditCardFactory
    {
        public static ICreditCard GetCreditCard(string cardType)
        {
            ICreditCard creditCard = null;
            if (cardType == null)
            {
                Console.WriteLine("Invalid Card");
            }
            if (cardType == "Money Back")
            {
                return new MoneyBack();
            }
            if (cardType == "Titanium")
            {
                return new Titanium();
            }
            if (cardType == "Visa")
            {
                return new Visa();
            }
            return creditCard;
        }
    }
}
