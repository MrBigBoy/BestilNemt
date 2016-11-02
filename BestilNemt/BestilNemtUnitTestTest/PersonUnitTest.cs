using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class PersonUnitTest
    {
        [TestMethod]
        public void AddPerson()
        {
            //var personCtr = new CustomerCtr(new PersonCtrTestClass());
            var person = new Person();
            //var flag = personCtr.CreatePerson(person);
            //Assert.AreEqual(1, flag);
        }

    }
}
