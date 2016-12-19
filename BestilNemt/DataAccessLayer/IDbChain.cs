using System.Collections.Generic;
using System.Data;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbChain
    /// </summary>
    public interface IDbChain
    {
        Chain GetChain(int id);
        //int AddChain(Chain chain);
        List<Chain> GetAllChains();
        //int DeleteChain(int id);
        DataTable GetChainData();
    }
}