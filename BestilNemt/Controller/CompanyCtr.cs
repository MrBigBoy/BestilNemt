using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class CompanyCtr
    {
        public IDbCompany DbCompany { get; set; }

        public CompanyCtr(IDbCompany dbCustomer)
        {
            DbCompany = dbCustomer;
        }

        /// <summary>
        /// Add a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Return 1 if Company is added, else 0
        /// </returns>
        public int AddCompany(Company company)
        {
            return ValidateCompanyInput(company) ? DbCompany.AddCompany(company) : 0;
        }

        /// <summary>
        /// Return all Companies
        /// </summary>
        /// <returns>
        /// List of Company
        /// </returns>
        public List<Company> FindAllCompany()
        {
            return DbCompany.FindAllCompany();
        }

        /// <summary>
        /// Delete a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Company is deleted, else 0
        /// </returns>
        public int RemoveCompany(int id)
        {
            return DbCompany.RemoveCompany(id);
        }

        /// <summary>
        /// Update a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Return 1 if Company if updated, else 0
        /// </returns>
        public int UpdateCompany(Company company)
        {
            return ValidateCompanyInput(company) ? DbCompany.AddCompany(company) : 0;
        }

        /// <summary>
        /// Return a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Company if found, else null
        /// </returns>
        public Company FindCompany(int id)
        {
            return DbCompany.FindCompany(id);
        }

        /// <summary>
        /// Return true if Company fields is correct, else false
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Return true if Company fields is correct, else false
        /// </returns>
        private bool ValidateCompanyInput(Company company)
        {
            return company?.Name != null && !company.Address.Equals("") && !company.Email.Equals("") &&
                company.PersonType == "Company" && !company.Name.Equals("");
        }
    }
}
