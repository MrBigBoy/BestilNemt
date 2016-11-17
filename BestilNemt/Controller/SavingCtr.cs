using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class SavingCtr
    {
        public IDbSaving DbSaving { get; set; }
        public SavingCtr(IDbSaving dbSaving)
        {
            DbSaving = dbSaving;
        }


        public int AddSaving(Saving saving, Product product)
        {
            if (product == null)
            {
                return 0;
            }
            return ValidateSavingInput(saving) ? DbSaving.AddSaving(saving, product) : 0;
        }

        public Saving FindSaving(int id)
        {
            return DbSaving.FindSaving(id);
        }

        public List<Saving> FindAllSavings()
        {
            return DbSaving.FindAllSavings();
        }

        public int UpdateSaving(Saving saving)
        {
            return DbSaving.UpdateSaving(saving);
        }

        public int DeleteSaving(int id)
        {
            return DbSaving.DeleteSaving(id);
        }

        private bool ValidateSavingInput(Saving saving)
        {
            return saving.SavingPercent > 0.0;
        }
    }
}
