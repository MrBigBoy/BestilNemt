using System.Collections.Generic;
using Models;

namespace DataAccessLayer

{
    public interface IDbCustomer
    {
        int Create(Customer customer);
        int RemoveCustomer(int id);
        Customer GetCustomer(int id);
        List<Customer> GetAllCustomer();
        int UpdateCustomer(Customer customer);
        int AddCustomerWithLogin(Customer customer, Login login); 
    }
    
}
