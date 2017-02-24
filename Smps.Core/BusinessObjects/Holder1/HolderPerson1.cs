using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smps.Core.Interfaces.Holder1.Repositories;

namespace Smps.Core.BusinessObjects.Holder1
{
   public class HolderPerson
    {
        private IHolderPersonRepository @object;

        

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name of the customer.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name of the customer.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number of the customer.</value>
        public long? MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the Parking slot number.
        /// </summary>
        /// <value>The parking slot number of the customer.</value>
        public string ParkingSlotNumber { get; set; }

        /// <summary>
        /// Gets or sets the User type.
        /// </summary>
        /// <value>The user type of the customer.</value>
        public string UserType { get; set; }

        public string username { get; set; }


        public int EmpNo { get; set; }

        public int OperationType { get; set; }



    }
}
