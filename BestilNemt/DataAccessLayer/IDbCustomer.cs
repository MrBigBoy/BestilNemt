using Models;

namespace DataAccessLayer

{
    /// <summary>
    /// Interfaces for DbCustomer
    /// </summary>
    public interface IDbCustomer
    {
        Customer GetCustomer(int id);
        int AddCustomerWithLogin(Customer customer, Login login); 
    }
    
}
