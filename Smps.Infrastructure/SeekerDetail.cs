//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smps.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class SeekerDetail
    {
        public int SeekerDetailId { get; set; }
        public Nullable<int> EmpNo { get; set; }
        public string ParkingSlotNumber { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime SlotReleasedDate { get; set; }
        public int AllocationType { get; set; }
        public short OperationType { get; set; }
    
        public virtual User User { get; set; }
    }
}
