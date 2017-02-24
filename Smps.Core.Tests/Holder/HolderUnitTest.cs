using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Core.BusinessObjects.Holder1;
using Moq;
using Smps.Core.Interfaces.Holder1.Repositories;

namespace Smps.Core.Tests.Holder
{
    [TestClass]
    public class Test_HolderUnit
    {
        public Smps.Core.BusinessObjects.Holder1.HolderPerson person { set; get; }

        private Mock<IHolderPersonRepository> TestRep;

        public Test_HolderUnit()
        {
            TestRep = new Mock<IHolderPersonRepository>();

            person = new HolderPerson {FirstName="mani",LastName="kant",EmpNo=12365,MobileNumber=47555555658,OperationType=1,ParkingSlotNumber="2",username="mani@gmail.com",UserType="Holder"};

        }


        [TestMethod]
        public void Test_releaseslot()
        {

            var obj = new Smps.Core.Services.HolderPerson(TestRep.Object);
            TestRep.Setup(u=>u.releaseslot(person)).Returns(1);
            var result = obj.releaseslot(person);
            Assert.AreEqual(result, 1);


        }
    }
}
