namespace CreationalPatterns.ObserverPattern
{
    internal class Observer
    {
        public void ObserverDemo()
        {
            Stock petrolStock = new ("pet",2400);
            Stock bitcoinStock = new ("bit",4400);

            Investor inverstor1 = new("Akash");
            Investor inverstor2 = new("Amol");
            Investor inverstor3 = new("Pratham");

            petrolStock.Attach(inverstor1);
            petrolStock.Attach(inverstor2);

            bitcoinStock.Attach(inverstor3);
            bitcoinStock.Attach(inverstor2);
            bitcoinStock.Notify();
            petrolStock.Notify();
        }
    }
}
