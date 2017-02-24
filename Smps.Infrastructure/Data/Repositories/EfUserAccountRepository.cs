//-----------------------------------------------------------------------
// <copyright file="EfUserAccountRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the User account repository.</summary>
//This contains all the crud operations related to user account.
//As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
//so that my team can start their development activity	
//Jira Id-2094
//This is using repository pattern
//Which acts as a wrapper over the underlying entity framework
//To make it persistent ignorant
//-----------------------------------------------------------------------

namespace Smps.Infrastructure.Data.Repositories
{
    using System;
    using System.Linq;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account.Repositories;
    using SMPS.CrossCutting.Constants;
    using SMPS.CrossCutting.CustomExceptions;
    using Smps.Core.Interfaces.Holder1.Repositories;
    using System.Collections.Generic;
    using Core.BusinessObjects.Holder1;
    using Core.Interfaces.Seeker.Repositories;
    using System.Data.SqlClient;
    using System.Data;
    using System.Globalization;
    
    /// <summary>
    /// This class contains the methods related to user account.
    /// This is consumed from core using dependency injection
    /// Which would be passed from the consumers
    /// Prefixed this with EF to represent that this is an entity framework class.
    /// </summary>
    public class EfUserAccountRepository : IUserAccountRepository
    {
        /// <summary>
        /// Gets the user profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        public UserProfile GetUserProfile(string userId)
        {
            try
            {
                //The User Profile Object.
                UserProfile userProfile;
                using (SMPSEntities123 objectContext = new SMPSEntities123())
                {
                    //Using IQueryable for better performance.
                    IQueryable<User> users = objectContext.Users;
                    //Getting the user model.
                    var user = users.Where(u => u.UserLoginId == userId).FirstOrDefault();
                    if (user != null)
                    {
                        //Getting the user prfile from user model.
                        userProfile = MapProperties(user);
                    }
                    else
                    {
                        //Exception if user not found
                        throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                    }
                }

                //return user profile
                return userProfile;
            }
            catch (NoDataFoundException)
            {
                //throw the exception
                throw;
            }
            catch (Exception)
            {
                //throw the exception
                throw;
            }
        }

        /// <summary>
        /// Validates the user and returns profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user profile.</returns>
        public UserProfile ValidateUser(string userId, string password)
        {
            //The User Profile Object.
            UserProfile userProfile = null;
            try
            {
                using (SMPSEntities123 objectContext = new SMPSEntities123())
                {
                    //Using IQueryable for better performance.
                    IQueryable<User> users = objectContext.Users;
                    //Getting the user model.
                    var user = users.Where(u => u.UserLoginId == userId && u.UserLoginPassword == password).FirstOrDefault();
                    //Checks if user is not null.
                    if (user != null)
                    {
                        // Getting the user prfile from user model.
                        //Maps the properties from user model to user profile
                        //And return the same.
                        userProfile = MapProperties(user);
                    }
                    else
                    {
                        //throw the exception
                        //With an error message.
                        throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                    }
                }

                //return user profile
                return userProfile;
            }
            catch (Exception)
            {
                //throw the exception
                //This is a generic exception
                throw;
            }
        }

        /// <summary>
        /// Maps the properties between data base object and business object.
        /// </summary>
        /// <param name="user">The user details.</param>
        /// <returns>The user profile.</returns>
        private static UserProfile MapProperties(User user)
        {
            //The User Profile Object.
            UserProfile userProfile = null;
            try
            {
                //Check for null condition
                if (user != null)
                {
                    //Mapping all the properties.
                    userProfile = new UserProfile();
                    //First Name
                    userProfile.FirstName = user.FirstName;
                    //Last Name
                    userProfile.LastName = user.LastName;
                    //Mobile Number
                    userProfile.MobileNumber = user.MobileNumber;
                    //Parking slot number.
                    userProfile.ParkingSlotNumber = user.ParkingSlotNumber;
                    //User Type.
                    userProfile.UserType = user.UserType;
                    //User Type.
                    userProfile.username = user.UserLoginId;
                    userProfile.EmpNo = user.EmpNo;
                }
                else
                {
                    //throw the exception
                    throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                }
            }
            catch (Exception)
            {
                //throw the exception
                //This is a generic exception
                throw;
            }

            //return user profile
            return userProfile;

        }




    }


    public class HolderPersonRepository : IHolderPersonRepository
    {

        public int releaseslot(HolderPerson HLD)
        {
            try
            { 
            HolderDetail holder = new HolderDetail();
            List<HolderDetail> list = new List<HolderDetail>();
            DateTime thisDay = DateTime.Today;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            using (SMPSEntities123 objectContext = new SMPSEntities123())
            {

                list = objectContext.HolderDetails.Where<HolderDetail>(h => h.EmpNo == HLD.EmpNo && h.SlotReleasedDate == date).ToList();
                if (list.Count <= 0)
                {
                    var affectedRows = objectContext.Database.ExecuteSqlCommand("holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}", HLD.EmpNo, HLD.ParkingSlotNumber, date, date, 0, 1);
                    return affectedRows = true ? 1 : 0;
                }
                else
                {

                    return 0;


                }

            }

            }catch(Exception ex)
            {



                throw ex;
            }



        }



    }


    public class SeekerRep : ISeekerRep
    {
        public string RequestForSlot(int EmpNo)
        {
            string Seekeroutputmessage;
           
            int PSN;
            int output;
            HolderDetail holder = new HolderDetail();
            List<HolderDetail> Hlist = new List<HolderDetail>();
            SeekerDetail seeker = new SeekerDetail();
            User usr;
            User HolderUser;
            List<SeekerDetail> skr;
            seeker.EmpNo = EmpNo;
            seeker.CreatedDate = DateTime.Now;
            List<User> list = new List<User>();
            DateTime thisDay = DateTime.Now;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;

            var SeekerdateAndTime = DateTime.Now;
            var Seekerdate = dateAndTime.Date;


            try
            {


                SMPSEntities123 objectContext = new SMPSEntities123();
            

                Hlist = objectContext.HolderDetails.Where<HolderDetail>(h => h.OperationType ==1 && h.CreatedDate==date).ToList();
                usr = objectContext.Users.Where<User>(u => u.EmpNo == EmpNo).SingleOrDefault();
                
                seeker.EmpNo = usr.EmpNo;
                string currentdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt = DateTime.ParseExact(currentdate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                seeker.CreatedDate = dt;

                if (Hlist.Count()>0)
                {
                    skr = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                    if (skr == null)
                    {
                        int empno = (int)Hlist[0].EmpNo;
                    //holder updation allocation and operation type
                    var affectedRows = objectContext.Database.ExecuteSqlCommand("UpadtingOperationandallocation @EmpNo={0},@CreatedDate={1}",Hlist[0].EmpNo,Hlist[0].CreatedDate);
                    HolderUser= objectContext.Users.Where<User>(u => u.EmpNo ==empno).SingleOrDefault();
                    PSN = Convert.ToInt32(HolderUser.ParkingSlotNumber);
                    //check once working r not
                    


                        

                        var Res =objectContext.Database.ExecuteSqlCommand("sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}", seeker.EmpNo, PSN, seeker.CreatedDate, seeker.CreatedDate, 1,0);
                        SeekerDetail SL = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).SingleOrDefault();
                       

                         output = (int)SL.SeekerDetailId;
                        Seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "You had Allocated having slot Number:" + SL.ParkingSlotNumber + " with Reference Number:" + output;

                        return Seekeroutputmessage;



                    }
                    else
                    {
                        SeekerDetail SL = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).SingleOrDefault();


                        output = (int)SL.SeekerDetailId;

                        return " sorry"+ usr.FirstName + "" + usr.LastName +  "You already raised a Request Today and Your Slot Number is" + SL.ParkingSlotNumber;
                       

                    }
                    
                }
                else
                {
                    var Res = objectContext.Database.ExecuteSqlCommand("sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}", seeker.EmpNo, null, seeker.CreatedDate, seeker.CreatedDate, 0, 1);
                    SeekerDetail SL = objectContext.SeekerDetails.Where(s => s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year && s.CreatedDate.Month == seeker.CreatedDate.Month && s.CreatedDate.Day == seeker.CreatedDate.Day).SingleOrDefault();


                    output = (int)SL.SeekerDetailId;

                    Seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "Thank you for request a slot You are Under waiting list with Reference Number:" + output;

                    return "Seekeroutputmessage";

                }



            }
            catch (Exception ex)
            {


                throw ex;

            }
        }

    }
}