using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbCompany
    /// </summary>
    public interface IDbCompany
    {
        int AddCompany(Company company);
        int DeleteCompany(int id);
        Company GetCompany(int id);
        List<Company> GetAllCompany();
        int UpdateCompany(Company company);
    }
}
