namespace CreationalPatterns.DecoratorPattern
{
    public interface Pizza
    {
        string MakePizza();
    }
    public class PlainPizza : Pizza
    {
        public string MakePizza()
        {
            return "Plain Pizza";
        }
    }

    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public virtual string MakePizza()
        {
            return pizza.MakePizza();
        }
    }

    public class ChickenPizza : PizzaDecorator
    {
        public ChickenPizza(Pizza pizza) : base(pizza)
        {
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + AddChicken();
        }
        private string AddChicken()
        {
            return "Chicken Added";

        }
    }
    public class VegPizza : PizzaDecorator
    {
        public VegPizza(Pizza pizza) : base(pizza)
        {
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + AddVegetables();
        }
        private string AddVegetables()
        {
            return "Vegetables Added";

        }
    }
}
