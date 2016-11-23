using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbCompany
    {
        int AddCompany(Models.Company company);
        int RemoveCompany(int id);
        Company FindCompany(int id);
        List<Company> FindAllCompany();
        int UpdateCompany(Company company);
    }
}
