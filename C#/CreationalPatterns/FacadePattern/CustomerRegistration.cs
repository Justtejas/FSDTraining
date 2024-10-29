namespace CreationalPatterns.FacadePattern
{
    internal class CustomerRegistration
    {
        public void RegisterCustomer(Customer customer)
        {
            ValidateCustomer validateCustomer = new();
            validateCustomer.IsValid(customer);
            CustomerDataAccessLayer customerDataAccessLayer = new();
            customerDataAccessLayer.SaveCustomer(customer);
            Notification notification = new();
            notification.SendNotification(customer);
        }
    }
}
