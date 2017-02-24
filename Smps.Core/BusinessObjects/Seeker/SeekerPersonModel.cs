using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.BusinessObjects.Seeker
{
    public class SeekerPersonModel
    {
        public int SeekerDetailId { get; set; }
        public Nullable<int> EmpNo { get; set; }
        public string ParkingSlotNumber { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime SlotReleasedDate { get; set; }
        public int AllocationType { get; set; }
        public short OperationType { get; set; }
        
    }

    



    
}
