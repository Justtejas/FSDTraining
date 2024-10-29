namespace CreationalPatterns.FacadePattern
{
    internal class Facade
    {
        public void FacadeDemo()
        {
            Customer customer = new();
            customer.CustomerID = 1;
            customer.CustomerName = "Tejas";
            customer.Location = "Pune";
            customer.MobileNumber = "0987654321";

            CustomerRegistration customerRegistration = new();
            customerRegistration.RegisterCustomer(customer);
        }
    }
}
