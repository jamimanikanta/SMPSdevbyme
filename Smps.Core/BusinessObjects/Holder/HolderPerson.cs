using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.BusinessObjects.Holder
{
    public class HolderPerson
    {
        public int Id { get; set; }
        public int EmpNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<long> MobileNumber { get; set; }
        public string UserLoginId { get; set; }
        public string UserLoginPassword { get; set; }
        public string UserType { get; set; }
        public string ParkingSlotNumber { get; set; }
        public string Location { get; set; }
        public short OperationType { get; set; }



    }
}
