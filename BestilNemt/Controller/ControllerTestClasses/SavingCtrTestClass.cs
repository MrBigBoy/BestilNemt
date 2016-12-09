using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class SavingCtrTestClass : IDbSaving
    {
        private List<Saving> Savings = new List<Saving>();
        private int IdCounter = 1;
        private int Flag = 0;

        public int AddSaving(Saving saving, Warehouse warehouse)
        {
            saving.Id = IdCounter;
            if (ValidateSavingInput(saving))
                Flag = 1;

            Savings.Add(saving);
            IdCounter++;
            return Flag;

        }

        public Saving GetSaving(int id)
        {
            return Savings.FirstOrDefault(savings => savings.Id == id);
        }

        public List<Saving> GetAllSavings()
        {
            return Savings;
        }

        public int UpdateSaving(Saving saving)
        {
            var returnedSaving = GetSaving(saving.Id);
            returnedSaving.StartDate = saving.StartDate;
            returnedSaving.EndDate = saving.EndDate;
            returnedSaving.SavingPercent = saving.SavingPercent;

            return 1;
        }

        public int DeleteSaving(int id)
        {
            return Savings.Remove(GetSaving(id)) ? 1 : 0;
        }

        private bool ValidateSavingInput(Saving saving)
        {
            if (saving.SavingPercent < 0.1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}