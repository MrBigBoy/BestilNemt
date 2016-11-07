using System;
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
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.CreateCompany(company);
            Assert.IsNull(companyCtr.findCompany(4));
        }
        [TestMethod]
        public void GetAllcompanys()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var company2 = new Company("Nordeaa", "Esmail.@gmail.com", "Pilevej 12", "Company", 123456782, 4);
            companyCtr.CreateCompany(company);
            companyCtr.CreateCompany(company2);
            Assert.AreEqual(2, companyCtr.GetAllCompany().Count);

        }

        [TestMethod]
        public void UpdateCompanyCVRFlag()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.CreateCompany(company);
            var flag = companyCtr.updateCompany(company);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void DeleteCompanyById()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.CreateCompany(company);
            var id = companyCtr.removeCompany(company.Id);
            Assert.AreEqual(1, id);
        }
        [TestMethod]
        public void DeleteCompanyByIdFail()
        {
            var companyCtr = new CompanyCtr(new CompanyCtrTestClasses());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            companyCtr.CreateCompany(company);
            var id = companyCtr.removeCompany(company.Id);
            Assert.AreNotEqual(0, id);
        }
        [TestMethod]
        public void AddDbCompany()
        {
            var dbCompany = new DbCompany1();
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = dbCompany.CreateCompany(company);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void getCompany()
        {
            var dbCompany = new DbCompany1();
            var company = dbCompany.FindCompany(3);
            Assert.IsNotNull(company);
        }

        [TestMethod]
        public void GetAllCompany()
        {
            var dbCompany = new DbCompany1();
            Assert.AreNotEqual(0,dbCompany.FindAllCompany().Count);
        }

        [TestMethod]
        public void AddCtrDbCompany()
        {
            var companyCtr = new CompanyCtr(new DbCompany1());
            var company = new Company("Nordea", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = companyCtr.CreateCompany(company);
            Assert.AreNotEqual(0,id);
        }

        [TestMethod]
        public void AddCtrDbCompanyFailName()
        {
            var companyCtr = new CompanyCtr(new DbCompany1());
            var company = new Company("", "Email.@gmail.com", "Pilevej 12", "Company", 12345678, 1);
            var id = companyCtr.CreateCompany(company);
            Assert.AreEqual(0, id);
        }


    }
}
