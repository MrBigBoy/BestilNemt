using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public interface IDbSaving
    {
        int AddSaving(Saving saving, Product product);
        Saving FindSaving(int id);
        List<Saving> FindAllSavings();
        int UpdateSaving(Saving saving);
        int DeleteSaving(int id);
    }
}
