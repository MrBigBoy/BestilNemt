using System;
using Controller;
using Controller.ControllerTestClasses;
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

        [TestMethod]
        public void CreateCompany()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Norea@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var flag = companyCtr.CreateCompany(company);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void CreateCompanyNoEmail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "", "Pilevej 12", "Company", 12345678, 1);
            var flag = companyCtr.CreateCompany(company);
            Assert.AreEqual(0, flag);
        }

        [TestMethod]
        public void FindCompanyById()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "dsds", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.CreateCompany(company);
            Assert.IsNotNull(companyCtr.findCompany(1));

        }

        [TestMethod]
        public void FindCompanyByIdFail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "dsds", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.CreateCompany(company);
            Assert.IsNull(companyCtr.findCompany(4));
        }
    }
}
