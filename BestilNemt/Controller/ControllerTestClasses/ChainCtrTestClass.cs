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
        private int idCounter = 1;

        public Chain GetChain(int id)
        {
            return chains.FirstOrDefault(chain => chain.Id == id);
        }

        public int AddChain(Chain chain)
        {
            chain.Id = idCounter;
            chains.Add(chain);
            idCounter++;
            return chain.Id;
        }

        public List<Chain> GetAllChains()
        {
            return chains;
        }

        public int UpdateChain(Chain chain)
        {
            var returnedChain = GetChain(chain.Id);
            returnedChain.Name = chain.Name;
            returnedChain.Cvr = chain.Cvr;
            returnedChain.Persons = chain.Persons;
            returnedChain.Shops = chain.Shops;

            return 1;

        }

        /// <summary>
        /// if chain was removes return 1 else 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteChain(int id)
        {
            return chains.Remove(GetChain(id)) ? 1 : 0;
        }

        public DataTable GetChainData()
        {
            throw new System.NotImplementedException();
        }
    }
}
