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
        int DeleteSaving(int id);
    }
}
