using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Infrastructure.Data.Repositories;
using Smps.Core.BusinessObjects.Holder1;
using Smps.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Smps.Core.Interfaces.Holder1.Repositories;

namespace SMPA.DAL.Tests.Holder
{
    [TestClass]
    public class HolderUnitTest: IDisposable
    {
        private bool disposedValue = false;
        private IHolderPersonRepository Hpr;
        public HolderPerson Hp;
        private WindsorContainer container;
        public HolderUnitTest()
        {
             

            Hp = new HolderPerson() { FirstName = "sindhuja", LastName = "rudroju", EmpNo = 519180, MobileNumber = 9948484684, OperationType = 1, ParkingSlotNumber = "2", username = "sindhuja_rudroju@epam.com", UserType = "Holder" };
            this.container = new WindsorContainer();
            this.container.Register(Classes.FromAssemblyNamed("Smps.Infrastructure").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            this.container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());






        }
        [TestMethod]
        public void Test_releaseslotRepo()
        {
            int Resdb;
            Hpr = new HolderPersonRepository();
            int res = Hpr.releaseslot(Hp);
            HolderDetail holder = new HolderDetail();
            List<HolderDetail> list = new List<HolderDetail>();
            DateTime thisDay = DateTime.Today;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            using (SMPSEntities123 objectContext = new SMPSEntities123())
            {

                list = objectContext.HolderDetails.Where<HolderDetail>(h => h.EmpNo == Hp.EmpNo && h.SlotReleasedDate == date).ToList();
                if (list.Count <= 0)
                {
                    var affectedRows = objectContext.Database.ExecuteSqlCommand("holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}", Hp.EmpNo, Hp.ParkingSlotNumber, date, date, 0, 1);
                    Resdb = affectedRows = true ? 1 : 0;
                }
                else
                {

                    Resdb = 0;


                }

            }
            Assert.AreEqual(res.GetType(), Resdb.GetType());


        }


        public void Dispose()
        {
            this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.container.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
