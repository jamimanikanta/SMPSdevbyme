using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Infrastructure.Data.Repositories;
using Smps.Core.Interfaces.Seeker.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Smps.Infrastructure;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace SMPA.DAL.Tests.Seeker
{
    [TestClass]
    public class SeekerUnitTest : IDisposable
    {

        private ISeekerRep Tsr;
        private WindsorContainer container;
        private bool disposedValue = false;
        public int TEmpno = 518935;
        public SeekerUnitTest()
        {
            this.container = new WindsorContainer();
            this.container.Register(Classes.FromAssemblyNamed("Smps.Infrastructure").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            this.container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            Tsr = new SeekerRep();
        }


        [TestMethod]
        public void Test_RequestForSlot()
        {
            string Res = Tsr.RequestForSlot(519562);
            string TestRes = GetResult(TEmpno);

            Assert.AreEqual(string.IsNullOrEmpty(Res), false);
            Assert.AreEqual(false, string.IsNullOrEmpty(TestRes));


        }


        public string GetResult(int TEmpno)
        {

            int PSN;
            int output;
            HolderDetail holder = new HolderDetail();
            List<HolderDetail> Hlist = new List<HolderDetail>();
            SeekerDetail seeker = new SeekerDetail();
            User usr;
            User HolderUser;
            List<SeekerDetail> skr;
            seeker.EmpNo = TEmpno;
            seeker.CreatedDate = DateTime.Now;
            List<User> list = new List<User>();
            DateTime thisDay = DateTime.Now;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;

            var SeekerdateAndTime = DateTime.Now;
            var Seekerdate = dateAndTime.Date;
            string Seekeroutputmessage;




            using (SMPSEntities123 objectContext = new SMPSEntities123())
            {

                Hlist = objectContext.HolderDetails.Where<HolderDetail>(h => h.OperationType == 1 && h.CreatedDate == date).ToList();
                usr = objectContext.Users.Where<User>(u => u.EmpNo == TEmpno).SingleOrDefault();

                seeker.EmpNo = usr.EmpNo;
                string currentdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt = DateTime.ParseExact(currentdate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                seeker.CreatedDate = dt;

                if (Hlist.Count() > 0)
                {
                    skr = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                    if (skr == null)
                    {
                        int empno = (int)Hlist[0].EmpNo;
                        //holder updation allocation and operation type
                        var affectedRows = objectContext.Database.ExecuteSqlCommand("UpadtingOperationandallocation @EmpNo={0},@CreatedDate={1}", Hlist[0].EmpNo, Hlist[0].CreatedDate);
                        HolderUser = objectContext.Users.Where<User>(u => u.EmpNo == empno).SingleOrDefault();
                        PSN = Convert.ToInt32(HolderUser.ParkingSlotNumber);
                        //check once working r not





                        var Res = objectContext.Database.ExecuteSqlCommand("sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}", seeker.EmpNo, PSN, seeker.CreatedDate, seeker.CreatedDate, 1, 0);
                        SeekerDetail SL = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).SingleOrDefault();


                        output = (int)SL.SeekerDetailId;
                        Seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "You had Allocated having slot Number:" + SL.ParkingSlotNumber + " with Reference Number:" + output;

                        return Seekeroutputmessage;



                    }
                    else
                    {
                        List<SeekerDetail> SL = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                        int count = SL.Count();

                        output = (int)SL[count-1].SeekerDetailId;

                        return " sorry" + usr.FirstName + "" + usr.LastName + "You already raised a Request Today and Your Slot Number is" + SL[count - 1].ParkingSlotNumber;


                    }

                }
                else
                {
                    var Res = objectContext.Database.ExecuteSqlCommand("sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}", seeker.EmpNo, null, seeker.CreatedDate, seeker.CreatedDate, 0, 1);
                   List< SeekerDetail> SL = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                    int count = SL.Count();

                    output = (int)SL[count-1].SeekerDetailId;

                    Seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "Thank you for request a slot You are Under waiting list with Reference Number:" + output;

                    return "Seekeroutputmessage";

                }



            }


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
