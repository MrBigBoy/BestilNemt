using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for Saving
    /// </summary>
    public interface IDbSaving
    {
        int AddSaving(Saving saving, Warehouse warehouse);
        Saving GetSaving(int id);
        //List<Saving> GetAllSavings();
        //int UpdateSaving(Saving saving);
        //int DeleteSaving(int id);
    }
}
