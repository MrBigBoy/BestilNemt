using DataAccessLayer;
using Models;

namespace Controller
{
    public class SavingCtr
    {
        public IDbSaving DbSaving { get; set; }

        /// <summary>
        /// Constructor for Saving controller
        /// </summary>
        /// <param name="dbSaving"></param>
        public SavingCtr(IDbSaving dbSaving)
        {
            DbSaving = dbSaving;
        }

        /// <summary>
        /// Add a Saving
        /// </summary>
        /// <param name="saving"></param>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Id of saving if added, else 0
        /// </returns>
        public int AddSaving(Saving saving, Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return 0;
            }
            return ValidateSavingInput(saving) ? DbSaving.AddSaving(saving, warehouse) : 0;
        }

        /// <summary>
        /// Get a Saving
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Saving if found, else null
        /// </returns>
        public Saving GetSaving(int id)
        {
            return DbSaving.GetSaving(id);
        }
        
        /// <summary>
        /// Delete a Saving
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if deleted, else 0
        /// </returns>
        public int DeleteSaving(int id)
        {
            return DbSaving.DeleteSaving(id);
        }

        /// <summary>
        /// Validate Saving fields
        /// </summary>
        /// <param name="saving"></param>
        /// <returns></returns>
        private static bool ValidateSavingInput(Saving saving)
        {
            return (saving.SavingPercent > 0.1);
        }
    }
}
