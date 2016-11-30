using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System;

namespace Controller
{
    public class CustomerCtr
    {
        public IDbCustomer DbCustomer { get; set; }

        /// <summary>
        /// The Constructor of Controlleren
        /// </summary>
        /// <param name="dbCustomer"></param>
        public CustomerCtr(IDbCustomer dbCustomer)
        {
            DbCustomer = dbCustomer;
        }

        /// <summary>
        /// Add a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return id of Customer if added, else 0
        /// </returns>
        public int AddCustomer(Customer customer)
        {
            return ValidatePersonInput(customer) ? DbCustomer.Create(customer) : 0;
        }

        /// <summary>
        /// Return a Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Customer if found, else null
        /// </returns>
        public Customer FindCustomer(int id)
        {
            return DbCustomer.FindCustomer(id);
        }

        /// <summary>
        /// Return all Customers
        /// </summary>
        /// <returns>
        /// List of Customer
        /// </returns>
        public List<Customer> GetAllCustomer()
        {
            return DbCustomer.FindAllCustomer();
        }

        /// <summary>
        /// Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Customer is deleted, else 0
        /// </returns>
        public int DeleteCustomer(int id)
        {
            return DbCustomer.RemoveCustomer(id);
        }

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return 1 if Customer is updated, else 0
        /// </returns>
        public int UpdateCustomer(Customer customer)
        {
            return ValidatePersonInput(customer) ? DbCustomer.UpdateCustomer(customer) : 0;
        }

        /// <summary>
        /// Validate the Customer fields
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return true if field is correct, else false
        /// </returns>
        private bool ValidatePersonInput(Customer customer)
        {
            return customer != null && !customer.Address.Equals("") && !customer.Name.Equals("") &&
                customer.Name != null && !customer.Address.Equals("") && customer.Address != null &&
                !customer.Email.Equals("") && customer.Email != null;
        }

        public int CreateCustomerWithLogin(Customer customer, Login login)
        {
            return DbCustomer.AddCustomerWithLogin(customer, login);
        }
    }
}
