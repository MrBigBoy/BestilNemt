using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public interface IDbCompany
    {
        int CreateCompany(Models.Company company);
        int RemoveCompany(int id);
        Company FindCompany(int id);
        List<Company> FindAllCompany();
        int UpdateCompany(Company company);
    }
}
