using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Smps.Core.Interfaces.Seeker.Repositories;
using Smps.Core.Services;

namespace Smps.Core.Tests.Seeker
{
    [TestClass]
    public class SeekerUnitTest
    {
        public int Empno = 518900;
        private Mock<ISeekerRep> TISR;
        SeekerService service;
        string result = "sucess";
        public SeekerUnitTest()
        {
            TISR = new Mock<ISeekerRep>();
            service = new SeekerService(TISR.Object);


        }
        [TestMethod]
        public void Test_RequestForSlot()
        {
            TISR.Setup(u => u.RequestForSlot(Empno)).Returns("sucess");

           var output= service.RequestForSlot(Empno);
            Assert.AreEqual(output, result);
        }
    }
}
