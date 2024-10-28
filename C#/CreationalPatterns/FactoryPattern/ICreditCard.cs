namespace CreationalPatterns.FactoryPattern
{
    internal interface ICreditCard
    {
        public int GetAnnualCharge();
        public string GetCardType();
        public int GetCreditLimit();
    }
    public class MoneyBack:ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 400;
        }
        public string GetCardType()
        {
            return "Money Back";
        }
        public int GetCreditLimit()
        {
            return 50000;
        }
    }
    public class Visa:ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 500;
        }
        public string GetCardType()
        {
            return "Visa";
        }
        public int GetCreditLimit()
        {
            return 60000;
        }
    }
    public class Titanium:ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 700;
        }
        public string GetCardType()
        {
            return "Titanium";
        }
        public int GetCreditLimit()
        {
            return 45000;
        }
    }
}
