using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbChain
    {
        Chain GetChain(int id);
        int AddChain(Chain chain);
        List<Chain> GetAllChains();
        int UpdateChain(Chain chain);
        int DeleteChain(int id);
    }
}