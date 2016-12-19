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
        
        public int DeleteSaving(int id)
        {
            return Savings.Remove(GetSaving(id)) ? 1 : 0;
        }

        private bool ValidateSavingInput(Saving saving)
        {
            return !(saving.SavingPercent < 0.1);
        }
    }
}