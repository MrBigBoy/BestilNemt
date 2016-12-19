using Models;

namespace DataAccessLayer

{
    /// <summary>
    /// Interfaces for DbCustomer
    /// </summary>
    public interface IDbCustomer
    {
        //int AddCustomer(Customer customer);
        //int DeleteCustomer(int id);
        Customer GetCustomer(int id);
        //List<Customer> GetAllCustomer();
        //int UpdateCustomer(Customer customer);
        int AddCustomerWithLogin(Customer customer, Login login); 
    }
    
}
