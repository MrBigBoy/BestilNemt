using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ChainUnitTest
    {
        /// <summary>
        /// Test a ChainCtr constructor
        /// The test is successfull if the instance is not null
        /// </summary>
        [TestMethod]
        public void ChainCtrInitialize()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            Assert.IsNotNull(chainCtr);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void AddChain()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            var flag = chainCtr.AddChain(chain);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned value is 0
        /// Cvr is not 8 char
        /// </summary>
        [TestMethod]
        public void AddChainInvalidCvr()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "323232", "Img path");
            var flag = chainCtr.AddChain(chain);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if chain is found (not null)
        /// </summary>
        [TestMethod]
        public void GetChainById()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            chainCtr.AddChain(chain);
            Assert.IsNotNull(chainCtr.GetChain(1));
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if chain is not found (null)
        /// </summary>
        [TestMethod]
        public void GetChainByIdFail()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            chainCtr.AddChain(chain);
            Assert.IsNull(chainCtr.GetChain(2));
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if the list of chains is two
        /// </summary>
        [TestMethod]
        public void GetAllChains()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            var chain2 = new Chain("MiniChain", "21212121", "Img path");
            chainCtr.AddChain(chain);
            chainCtr.AddChain(chain2);
            Assert.AreEqual(2, chainCtr.GetAllChains().Count);
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned value = 1
        /// </summary>
        [TestMethod]
        public void UpdateChainCheckFlag()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            chainCtr.AddChain(chain);
            chain.Name = "Hello World";
            var flag = chainCtr.UpdateChain(chain);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned name equals "Hello World"
        /// </summary>
        [TestMethod]
        public void UpdateChainCheckName()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            chainCtr.AddChain(chain);
            var chain2 = new Chain
            {
                Id = 1,
                Name = "Hello World",
                Cvr = "12121212"
            };
            chainCtr.UpdateChain(chain2);
            var returnedChain = chainCtr.GetChain(1);
            Assert.AreEqual("Hello World", returnedChain.Name);
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned value is 1
        /// </summary>
        [TestMethod]
        public void DeleteChainById()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            chainCtr.AddChain(chain);
            var id = chainCtr.DeleteChain(chain.Id);
            Assert.AreEqual(1, id);
        }

        /// <summary>
        /// Test a ChainCtr with the ChainCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned value is 1
        /// </summary>
        [TestMethod]
        public void DeleteChainByIdFail()
        {
            var chainCtr = new ChainCtr(new ChainCtrTestClass());
            var chain = new Chain
            {
                Name = "MiniChain",
                Cvr = "12121212"
            };
            chainCtr.AddChain(chain);
            var id = chainCtr.DeleteChain(chain.Id);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test af DbChain
        /// The test is successfull if the returned id is not 0
        /// </summary>
        [TestMethod]
        public void AddDbChain()
        {
            var dbChain = new DbChain();
            var chain = new Chain("MiniChain", "12121212", "Img path");
            var id = dbChain.AddChain(chain);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test af dbChain
        /// The test is successfull if the chain is not null
        /// </summary>
        [TestMethod]
        public void GetDbChain()
        {
            var dbChain = new DbChain();
            var chain = dbChain.GetChain(1);
            Assert.IsNotNull(chain);
        }

        /// <summary>
        /// Test af dbChain
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void UpdateDbChain()
        {
            var dbChain = new DbChain();
            var chain = new Chain
            {
                Id = 1,
                Name = "Test World",
                Cvr = "12121212",
                ImgPath = "Img Path"
            };
            var returnedValue = dbChain.UpdateChain(chain);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test af dbChain
        /// The test is successfull if the returned value is not 1
        /// because there is no chain with id = 0
        /// </summary>
        [TestMethod]
        public void UpdateDbChainFail()
        {
            var dbChain = new DbChain();
            var chain = new Chain
            {
                Id = 0,
                Name = "Test World",
                Cvr = "12121212",
                ImgPath = "Img Path"
            };
            var returnedValue = dbChain.UpdateChain(chain);
            Assert.AreNotEqual(1, returnedValue);
        }

        /// <summary>
        /// Test af dbChain
        /// The test is successfull if the returned value is 1
        /// Require testMethod AddDbChain
        /// </summary>
        [TestMethod]
        public void DelDbChain()
        {
            var dbChain = new DbChain();
            var chain = new Chain("Test World", "12121212", "Img path");
            var id = dbChain.AddChain(chain);
            var returnedValue = dbChain.DeleteChain(id);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test af dbChain
        /// The test is successfull if the returned value is 1
        /// Require testMethod AddDbChain
        /// </summary>
        [TestMethod]
        public void GetAllDbChain()
        {
            var dbChain = new DbChain();
            Assert.AreNotEqual(0, dbChain.GetAllChains().Count);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned id is  not 0
        /// </summary>
        [TestMethod]
        public void AddCtrDbChain()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = new Chain("MiniChain", "12121212", "Img path");
            var id = chainCtr.AddChain(chain);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned id is 0
        /// Name is empty
        /// </summary>
        [TestMethod]
        public void AddCtrDbChainFailName()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = new Chain("", "12121212", "Img path");
            var id = chainCtr.AddChain(chain);
            Assert.AreEqual(0, id);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned id is 0
        /// Cvr is not 8 char
        /// </summary>
        [TestMethod]
        public void AddCtrDbChainFailCvr()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = new Chain("MiniChain", "12", "Img path");
            var id = chainCtr.AddChain(chain);
            Assert.AreEqual(0, id);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the chain is not null
        /// </summary>
        [TestMethod]
        public void GetCtrDbChain()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = chainCtr.GetChain(1);
            Assert.IsNotNull(chain);
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void UpdateCtrDbChain()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = new Chain
            {
                Id = 1,
                Name = "Test World",
                Cvr = "12121212",
                ImgPath = "Img Path"
            };
            var returnedValue = chainCtr.UpdateChain(chain);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a ChainCtr
        ///  The test is successfull if the returned value is not 1 
        /// because there is no chain with id = 0
        /// </summary>
        [TestMethod]
        public void UpdateCtrDbChainFail()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = new Chain
            {
                Id = 0,
                Name = "Test World",
                Cvr = "12121212",
                ImgPath = "Img Path"
            };
            var returnedValue = chainCtr.UpdateChain(chain);
            Assert.AreNotEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a ChainCtr
        ///  The test is successfull if the returned value is 1
        ///  Require testMethod AddDbChain 
        /// </summary>
        [TestMethod]
        public void DelCtrDbChain()
        {
            var chainCtr = new ChainCtr(new DbChain());
            var chain = new Chain("Test World", "12121212", "Img path");
            var id = chainCtr.AddChain(chain);
            var returnedValue = chainCtr.DeleteChain(id);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a ChainCtr
        ///  The test is successfull if the returned value is 1
        ///  Require testMethod AddDbChain 
        /// </summary>
        [TestMethod]
        public void GetAllCtrDbChain()
        {
            var chainCtr = new ChainCtr(new DbChain());
            Assert.AreNotEqual(0, chainCtr.GetAllChains().Count);
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned id is not 0
        /// </summary>
        [TestMethod]
        public void AddChainWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var chain = new Chain("new chain", "15987533", "Img path");
                var i = proxy.AddChain(chain);
                Assert.AreNotEqual(0, i);
            }
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned id is 0
        /// Cvr is not 8 char
        /// </summary>
        [TestMethod]
        public void AddChainWcfFailCvr()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var chain = new Chain("new chain", "87533", "Img path");
                var i = proxy.AddChain(chain);
                Assert.AreEqual(0, i);
            }
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned id is 0
        /// Name is empty
        /// </summary>
        [TestMethod]
        public void AddChainWcfFailName()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var chain = new Chain("", "82227533", "Img path");
                var i = proxy.AddChain(chain);
                Assert.AreEqual(0, i);
            }
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned object is not null 
        /// </summary>
        [TestMethod]
        public void FindChainWcfById()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.IsNotNull(proxy.GetChain(1));
            }
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned object is null 
        /// </summary>
        [TestMethod]
        public void FindChainWcfByIdFail()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.IsNull(proxy.GetChain(150));
            }
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned list is not empty 
        /// </summary>
        [TestMethod]
        public void FindAllChainWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.AreNotEqual(0, proxy.GetAllChains().Length);
            }
        }

        /// <summary>
        /// Test a ChainCtr
        /// The test is successfull if the returned object name is the same given new name
        /// </summary>
        [TestMethod]
        public void UpdateChainWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var chain = new Chain("MiniChain", "12121212", "Img path");
                var returnedId = proxy.AddChain(chain);
                var chain1 = new Chain
                {
                    Id = returnedId,
                    Name = "UpdatedName",
                    Cvr = "12121212",
                    ImgPath = "Img path"
                };
                proxy.UpdateChain(chain1);
                var returnedChain = proxy.GetChain(returnedId);
                Assert.AreEqual("UpdatedName", returnedChain.Name);
            }
        }

        /// <summary>
        /// Test Chain through Wcf
        /// The test is successfull if the returned object is not null 
        /// </summary>
        [TestMethod]
        public void DeleteChainWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var chain = new Chain("ChainToDelete", "12121212", "Img path");
                var returnedId = proxy.AddChain(chain);
                var flag = proxy.DeleteChain(returnedId);
                Assert.AreEqual(1, flag);
            }
        }
    }
}

