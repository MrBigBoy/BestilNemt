using System.Collections.Generic;
using Models;

namespace DataAccessLayer

{
    public interface IDbCustomer
    {
        int Create(Customer customer);
        int RemoveCustomer(int id);
        Customer FindCustomer(int id);
        List<Customer> FindAllCustomer();
        int UpdateCustomer(Customer customer);
    }
    
}
