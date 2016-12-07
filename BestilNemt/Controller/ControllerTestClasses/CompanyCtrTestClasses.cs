using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
   public class CompanyCtrTestClasses : IDbCompany
    {
        private List<Company> companys = new List<Company>();
        private int idCounter = 1;
        private int flag = 0;
   
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
    

        public int AddCompany(Company company)
        {
            company.Id = idCounter;
            if (ValidateCompanyInput(company))
                flag = 1;

            companys.Add(company);
            idCounter++;

            return flag;
        }

        public int DeleteCompany(int id)
        {
             return companys.Remove(GetCompany(id)) ? 1 : 0;
        }

        public Company GetCompany(int id)
        {
            return companys.FirstOrDefault(company => company.Id == id);
        }

        public List<Company> GetAllCompany()
        {
            return companys;
        }

        public int UpdateCompany(Company company)
        {
            var returendCompany = (GetCompany(company.Id));
            returendCompany.Name = company.Name;
            returendCompany.Address = company.Address;
           

            return 1;
        }
    }
}
