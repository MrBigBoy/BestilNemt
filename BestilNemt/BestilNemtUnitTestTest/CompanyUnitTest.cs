using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class CompanyUnitTest
    {
        [TestMethod]
        public void CompanyCtrInitialize()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            Assert.IsNotNull(companyCtr);
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Test is sucsessful if all customer input values are valid and return value is not 0 
        /// </summary>
        [TestMethod]
        public void AddCompany()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Norea@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var flag = companyCtr.AddCompany(company);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Test for invalid input email
        /// Test is sucsessful if validation of input failed ad returned value is 0
        /// </summary>
        /// 
        [TestMethod]
        public void AddCompanyNoEmail()
        {

            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "", "Pilevej 12", "Company", 12345678, 1);
            var flag = companyCtr.AddCompany(company);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Test for Company object with given id is found and return value is not null
        /// </summary>

        [TestMethod]
        public void FindCompanyById()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "dsds", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            Assert.IsNotNull(companyCtr.FindCompany(1));

        }

        /// <summary>
        /// Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Tést for the company object with given id is not found return with be null 
        /// </summary>
        [TestMethod]
        public void FindCompanyByIdFail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            Assert.IsNull(companyCtr.FindCompany(4));
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Test for the returned list size is equal to expected one
        /// </summary>
        [TestMethod]
        public void FindAllcompanys()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var company2 = new Company("Nordeaa", "Esmail.@gmail.com", "Pilevej 12", "Company", 123456782, 4);
            companyCtr.AddCompany(company);
            companyCtr.AddCompany(company2);
            Assert.AreEqual(2, companyCtr.FindAllCompany().Count);
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        ///  Test for return Cvr is equal to the new one. 
        /// </summary>
        [TestMethod]
        public void UpdateCompanyCvrFlag()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            var flag = companyCtr.UpdateCompany(company);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Test is suxsessful if returned is 1, it means that a company with id = 1, 
        /// is found and DeleteCompany metothe was sucsessfull 
        /// </summary>
        [TestMethod]
        public void DeleteCompanyById()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            var id = companyCtr.RemoveCompany(company.Id);
            Assert.AreEqual(1, id);
        }

        /// <summary>
        ///  Test only CompanyCtr using CompanyCrtTestClass that simulates database.
        /// Test is suxsessful if returned is 0, it means that a company with id = , 
        /// is not found and there for will not get delete. 
        [TestMethod]
        public void DeleteCompanyByIdFail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            var id = companyCtr.RemoveCompany(company.Id);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test only DbCompany 
        /// Test is sucsessful if all Company input values are valid and returned value is not 0
        /// </summary>
        [TestMethod]
        public void AddDbCompany()
        {
            var dbCompany = new DbCompany();
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = dbCompany.AddCompany(company);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test only DbCompany 
        /// Test is sucsessfull if returned company object is not null 
        /// </summary>

        [TestMethod]
        public void FindCompany()
        {
            var dbCompany = new DbCompany();
            var company = dbCompany.FindCompany(3);
            Assert.IsNotNull(company);
        }

        /// <summary>
        /// Test only DbCompany 
        /// Test is sucsessfull if returned company object is not null 
        /// </summary>
        [TestMethod]
        public void FindAllCompany()
        {
            var dbCompany = new DbCompany();
            var i = dbCompany.FindAllCompany();
            var j = i.Count;
            Assert.AreNotEqual(0, i);
        }

        /// <summary>
        /// Test both CTR And DB 
        /// 
        /// </summary>
        [TestMethod]
        public void AddCtrDbCompany()
        {
            var companyCtr = new CompanyCtr(new DbCompany());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = companyCtr.AddCompany(company);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test both CTR And DB 
        /// 
        /// </summary>
        [TestMethod]
        public void AddCtrDbCompanyFailName()
        {
            var companyCtr = new CompanyCtr(new DbCompany());
            var company = new Company("", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = companyCtr.AddCompany(company);
            Assert.AreEqual(0, id);
        }

        //[TestMethod]
        //public void updateCompanyWcf()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var company = proxy.FindCompany(3);
        //        var log = new Login(222,"fd","FDF",3232);
        //        if (company != null)
        //        {
        //            company.Name = "UCN";
        //            company.Address = "vej";
        //            company.Email = "email@email.com";
        //            company.CVR = 123455678;
        //            company.Kontonr = 2121212;

        //        }
        //        Assert.IsNotNull(log);
        //        var flag = proxy.UpdateCompany(company);
        //        Assert.AreEqual(0, flag);
        //    }


        //}

        [TestMethod]
        public void findme()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var company = proxy.FindCompany(3);
                Assert.IsNotNull(company);
            }
        }
    }
}