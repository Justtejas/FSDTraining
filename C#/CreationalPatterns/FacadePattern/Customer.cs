namespace CreationalPatterns.FacadePattern
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Location { get; set; }
        
    }

    public class ValidateCustomer
    {
        public bool IsValid(Customer customer)
        {
            Console.WriteLine("Is Valid");
            Console.WriteLine("Mobile no is valid");
            return true;
        }
    }

    public class CustomerDataAccessLayer
    {
        public void SaveCustomer(Customer customer)
        {
            Console.WriteLine("Saved the details in DB");
        }
    }

    public class Notification
    {
        public void SendNotification(Customer customer)
        {
            Console.WriteLine("Registration Success");
        }
    }
}
