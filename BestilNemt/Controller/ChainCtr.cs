using Models;
using DataAccessLayer;
using System.Collections.Generic;
using System;
using System.Data;

namespace Controller
{
    public class ChainCtr
    {
        public IDbChain DbChain { get; set; }

        /// <summary>
        /// Constructor for Chain controller
        /// </summary>
        /// <param name="dbChain"></param>
        public ChainCtr(IDbChain dbChain)
        {
            DbChain = dbChain;
        }

        /// <summary>
        /// Get a Chain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Chain if found, else null
        /// </returns>
        public Chain GetChain(int id)
        {
            return DbChain.GetChain(id);
        }

        /// <summary>
        /// Get all Chains
        /// </summary>
        /// <returns>
        /// List of Chain
        /// </returns>
        public List<Chain> GetAllChains()
        {
            return DbChain.GetAllChains();
        }

        /// <summary>
        /// Delete a Chain
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// return 1 if deleted, else 0
        /// </returns>
        public int DeleteChain(int id)
        {
            return DbChain.DeleteChain(id);
        }

        /// <summary>
        /// Add a Chain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// Return 1 if added, else 0
        /// </returns>
        public int AddChain(Chain chain)
        {
            return ValidateChainInput(chain) ? DbChain.AddChain(chain) : 0;
        }

        /// <summary>
        /// Update a Chain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// Return 1 if updated, else 0
        /// </returns>
        public int UpdateChain(Chain chain)
        {
            return ValidateChainInput(chain) ? DbChain.UpdateChain(chain) : 0;
        }

        /// <summary>
        /// Method to validate Chain fields
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// True if fields is correct, else false
        /// </returns>
        private static bool ValidateChainInput(Chain chain)
        {
            return chain != null && chain.Cvr.Length == 8 &&
                   !string.IsNullOrEmpty(chain.Name);
        }

        public DataTable GetChainData()
        {
            return DbChain.GetChainData();
        }
    }
}
