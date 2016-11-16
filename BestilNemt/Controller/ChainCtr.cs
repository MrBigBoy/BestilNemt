using Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Controller
{
    public class ChainCtr
    {
        public IDbChain DbChain { get; set; }

        public ChainCtr(IDbChain dbChain)
        {
            DbChain = dbChain;
        }

        public Chain GetChain(int id)
        {
            return DbChain.GetChain(id);
        }

        public List<Chain> GetAllChains()
        {
            return DbChain.GetAllChains();
        }

        public int DeleteChain(int id)
        {
            return DbChain.DeleteChain(id);
        }

        public int AddChain(Chain chain)
        {
            return ValidateChainInput(chain) ? DbChain.AddChain(chain) : 0;
        }

        public int UpdateChain(Chain chain)
        {
            return ValidateChainInput(chain) ? DbChain.UpdateChain(chain) : 0;
        }

        private bool ValidateChainInput(Chain chain)
        {
            if (chain == null || chain.CVR.Length != 8 || chain.Name.Equals("")
                || chain.Name == null || chain.Address.Equals("")
                || chain.Address == null)
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
