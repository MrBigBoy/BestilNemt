using System;
using Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            var id = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "INSERT INTO Chain (chainName, chainCvr, chainImgPath) OUTPUT Inserted.chainId values (@ChainName, @ChainCvr, @ChainImgPath)";
                    cmd.Parameters.AddWithValue("ChainName", chain.Name);
                    cmd.Parameters.AddWithValue("ChainCvr", chain.Cvr);
                    cmd.Parameters.AddWithValue("ChainImgPath", chain.ImgPath);
                    id = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
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
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Chain SET chainName = @ChainName, chainCVR = @ChainCvr, chainImgPath = @ChainImgPath where chainId = @ChainId";
                    cmd.Parameters.AddWithValue("ChainId", chain.Id);
                    cmd.Parameters.AddWithValue("ChainName", chain.Name);
                    cmd.Parameters.AddWithValue("ChainCvr", chain.Cvr);
                    cmd.Parameters.AddWithValue("ChainImgPath", chain.ImgPath);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
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
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DELETE FROM Chain WHERE chainId = @ChainId";
                    cmd.Parameters.AddWithValue("ChainId", id);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return i;
        }
    }
}
