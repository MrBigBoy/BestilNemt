using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int CreateCompany(Company company)
        {
            return ValidateCompanyInput(company) ? DbCompany.CreateCompany(company) : 0;
        }

        public List<Company> GetAllCompany()
        {
            return DbCompany.FindAllCompany(); 
        }

        public int removeCompany(int id)
        {
          return  DbCompany.RemoveCompany(id);
        }

        public int updateCompany(Company company)
        {
            return ValidateCompanyInput(company) ? DbCompany.CreateCompany(company) : 0;
           
        }

        public Company findCompany(int id)
        {
           return DbCompany.FindCompany(id);
        }
        private bool ValidateCompanyInput(Company company)
        {
            if (company == null || company.Name == null || company.Address.Equals("")
                || company.Email.Equals("") || company.PersonType != "Company"
                || company.Name.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
