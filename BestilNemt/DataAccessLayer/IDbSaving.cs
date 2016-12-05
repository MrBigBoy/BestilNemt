using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbSaving
    {
        int AddSaving(Saving saving, Product product);
        Saving GetSaving(int id);
        List<Saving> GetAllSavings();
        int UpdateSaving(Saving saving);
        int DeleteSaving(int id);
    }
}
