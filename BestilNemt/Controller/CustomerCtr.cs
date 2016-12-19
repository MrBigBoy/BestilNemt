using DataAccessLayer;
using Models;

namespace Controller
{
    public class CustomerCtr
    {
        public IDbCustomer DbCustomer { get; set; }

        /// <summary>
        /// The Constructor of Customer controller
        /// </summary>
        /// <param name="dbCustomer"></param>
        public CustomerCtr(IDbCustomer dbCustomer)
        {
            DbCustomer = dbCustomer;
        }
        
        /// <summary>
        /// Get a Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Customer if found, else null
        /// </returns>
        public Customer GetCustomer(int id)
        {
            return DbCustomer.GetCustomer(id);
        }
        
        /// <summary>
        /// Add a Customer with Login
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="login"></param>
        /// <returns>
        /// Id of Customer if added, else 0
        /// </returns>
        public int AddCustomerWithLogin(Customer customer, Login login)
        {
            return ValidatePersonInput(customer) ? DbCustomer.AddCustomerWithLogin(customer, login) : 0;
        }

        /// <summary>
        /// Validate the Customer fields
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return true if field is correct, else false
        /// </returns>
            // ReSharper disable once SuggestBaseTypeForParameter
        private static bool ValidatePersonInput(Customer customer)
        {
            return !string.IsNullOrEmpty(customer?.Address) && !string.IsNullOrEmpty(customer.Name) && !string.IsNullOrEmpty(customer.Email);
        }
    }
}
