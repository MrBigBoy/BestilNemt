using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbCompany
    {
        int AddCompany(Models.Company company);
        int RemoveCompany(int id);
        Company GetCompany(int id);
        List<Company> GetAllCompany();
        int UpdateCompany(Company company);
    }
}
