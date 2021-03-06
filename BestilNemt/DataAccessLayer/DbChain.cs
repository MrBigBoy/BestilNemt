﻿using Models;
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
                    // Build the Chain object
                    chain = ObjectBuilder.CreateChain(reader);
                }
            }
            return chain;
        }

        ///// <summary>
        ///// Add a Chain
        ///// </summary>
        ///// <param name="chain"></param>
        ///// <returns>
        ///// Id of Chain if added, else 0
        ///// </returns>
        //public int AddChain(Chain chain)
        //{
        //    var id = 0;
        //    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set the isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "INSERT INTO Chain (chainName, chainCvr, chainImgPath) OUTPUT Inserted.chainId values (@ChainName, @ChainCvr, @ChainImgPath)";
        //            cmd.Parameters.AddWithValue("ChainName", chain.Name);
        //            cmd.Parameters.AddWithValue("ChainCvr", chain.Cvr);
        //            cmd.Parameters.AddWithValue("ChainImgPath", chain.ImgPath);
        //            // Get the id
        //            id = (int)cmd.ExecuteScalar();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return id;
        //}

        /// <summary>
        /// Get all Chains
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
                    // Build the Chain object
                    var chain = ObjectBuilder.CreateChain(reader);
                    // Add the chain to the list
                    chains.Add(chain);
                }
            }
            return chains;
        }

        ///// <summary>
        ///// Delete a Chain
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Chain is deleted, else 0
        ///// </returns>
        //public int DeleteChain(int id)
        //{
        //    var i = 0;
        //    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "DELETE FROM Chain WHERE chainId = @ChainId";
        //            cmd.Parameters.AddWithValue("ChainId", id);
        //            i = cmd.ExecuteNonQuery();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;
        //}

        public DataTable GetChainData()
        {
            const string cmdString = "Select chainId, chainName From Chain";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                //Opens the connetion and sets the qurey to the cmdstring
                conn.Open();
                var cmd = new SqlCommand(cmdString, conn);
                //Adapts the data that the SQL returnns
                var sda = new SqlDataAdapter(cmd);
                //Makes a new table
                var dt = new DataTable("Kæder");
                //Fills the tabel
                sda.Fill(dt);
                return dt;
            }
        }
    }
}
