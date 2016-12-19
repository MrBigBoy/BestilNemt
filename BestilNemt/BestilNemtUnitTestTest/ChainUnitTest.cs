using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;

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
        /// The test is successfull if the returned object is not null 
        /// </summary>
        [TestMethod]
        public void GetChainWcfById()
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
        public void GetChainWcfByIdFail()
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
        public void GetAllChainWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.AreNotEqual(0, proxy.GetAllChains().Length);
            }
        }
    }
}

