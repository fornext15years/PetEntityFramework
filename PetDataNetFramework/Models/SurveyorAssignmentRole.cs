//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetDataNetFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveyorAssignmentRole
    {
        public long Idx { get; set; }
        public long SurveyorID { get; set; }
        public long RowVersion { get; set; }
        public long AssignmentID { get; set; }
        public bool InActive { get; set; }
    
        public virtual Assignment Assignment { get; set; }
        public virtual Surveyor Surveyor { get; set; }
    }
}