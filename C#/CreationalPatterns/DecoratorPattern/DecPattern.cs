namespace CreationalPatterns.DecoratorPattern
{
    internal class DecPattern
    {
        public void DecPatternDemo()
        {
            PlainPizza plainPizza = new();
            string pizza  = plainPizza.MakePizza();
            Console.WriteLine(pizza);

            PizzaDecorator pizzaDecorator = new ChickenPizza(plainPizza);
            string chickenPizza = pizzaDecorator.MakePizza();
            Console.WriteLine(chickenPizza);
            pizzaDecorator = new VegPizza(plainPizza);
            string vegPizza = pizzaDecorator.MakePizza();
            Console.WriteLine(vegPizza);
        }
    }
}
