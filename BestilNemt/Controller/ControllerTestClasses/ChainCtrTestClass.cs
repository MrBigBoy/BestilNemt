using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class ChainCtrTestClass : IDbChain
    {
        private List<Chain> chains = new List<Chain>();
       
        public Chain GetChain(int id)
        {
            return chains.FirstOrDefault(chain => chain.Id == id);
        }

        public List<Chain> GetAllChains()
        {
            return chains;
        }

        public DataTable GetChainData()
        {
            return new DataTable();
        }
    }
}
