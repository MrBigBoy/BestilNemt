using Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbChain : IDbChain
    {
        /// <summary>
        /// Return a Chain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Chain if found, else null
        /// </returns>
        public Chain GetChain(int id)
        {
            Chain chain = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Chain where chainId = @ChainId", conn);
                command.Parameters.AddWithValue("ChainId", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chain = ObjectBuilder.CreateChain(reader);
                }
            }
            return chain;
        }

        /// <summary>
        /// Add a Chain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// Return 1 if Chain is added, else 0
        /// </returns>
        public int AddChain(Chain chain)
        {
            int id;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("INSERT INTO Chain (chainName, chainCVR, chainImgPath) OUTPUT Inserted.chainId values (@ChainName, @ChainCvr, @ChainImgPath)", conn);
                command.Parameters.AddWithValue("ChainName", chain.Name);
                command.Parameters.AddWithValue("ChainCvr", chain.CVR);
                command.Parameters.AddWithValue("ChainÍmgPath", chain.ImgPath);
                id = (int)command.ExecuteScalar();
            }
            return id;
        }

        /// <summary>
        /// Return a list of all chains
        /// </summary>
        /// <returns>
        /// List of Chain
        /// </returns>
        public List<Chain> GetAllChains()
        {
            var chains = new List<Chain>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Chain", conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var chain = ObjectBuilder.CreateChain(reader);
                    chains.Add(chain);
                }
            }
            return chains;
        }

        /// <summary>
        /// Update a Chain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// Return 1 if Chain is updated, else 0
        /// </returns>
        public int UpdateChain(Chain chain)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("UPDATE Chain SET chainName = @ChainName, chainCVR = @ChainCvr, chainImgPath = @ChainImgPath where chainId = @ChainId", conn);
                command.Parameters.AddWithValue("ChainId", chain.Id);
                command.Parameters.AddWithValue("ChainName", chain.Name);
                command.Parameters.AddWithValue("ChainCvr", chain.CVR);
                command.Parameters.AddWithValue("ChainImgPath", chain.ImgPath);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Delete a Chain
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Chain is deleted, else 0
        /// </returns>
        public int DeleteChain(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("DELETE FROM Chain WHERE chainId = @ChainId", conn);
                command.Parameters.AddWithValue("ChainId", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }
    }
}
