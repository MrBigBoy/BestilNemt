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

        [TestMethod]
        public void AddCompany()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Norea@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var flag = companyCtr.AddCompany(company);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void AddCompanyNoEmail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "", "Pilevej 12", "Company", 12345678, 1);
            var flag = companyCtr.AddCompany(company);
            Assert.AreEqual(0, flag);
        }

        [TestMethod]
        public void FindCompanyById()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "dsds", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            Assert.IsNotNull(companyCtr.FindCompany(1));

        }

        [TestMethod]
        public void FindCompanyByIdFail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            Assert.IsNull(companyCtr.FindCompany(4));
        }
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

        [TestMethod]
        public void UpdateCompanyCvrFlag()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            var flag = companyCtr.UpdateCompany(company);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void DeleteCompanyById()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            var id = companyCtr.RemoveCompany(company.Id);
            Assert.AreEqual(1, id);
        }
        [TestMethod]
        public void DeleteCompanyByIdFail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.AddCompany(company);
            var id = companyCtr.RemoveCompany(company.Id);
            Assert.AreNotEqual(0, id);
        }
        [TestMethod]
        public void AddDbCompany()
        {
            var dbCompany = new DbCompany();
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = dbCompany.AddCompany(company);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void FindCompany()
        {
            var dbCompany = new DbCompany();
            var company = dbCompany.FindCompany(3);
            Assert.IsNotNull(company);
        }

        [TestMethod]
        public void FindAllCompany()
        {
            var dbCompany = new DbCompany();
            Assert.AreNotEqual(0, dbCompany.FindAllCompany().Count);
        }

        [TestMethod]
        public void AddCtrDbCompany()
        {
            var companyCtr = new CompanyCtr(new DbCompany());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = companyCtr.AddCompany(company);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddCtrDbCompanyFailName()
        {
            var companyCtr = new CompanyCtr(new DbCompany());
            var company = new Company("", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = companyCtr.AddCompany(company);
            Assert.AreEqual(0, id);
        }
    }
}
