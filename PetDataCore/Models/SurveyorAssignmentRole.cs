using System;
using System.Collections.Generic;

namespace PetDataCore.Models
{
    public partial class SurveyorAssignmentRole
    {
        public long Idx { get; set; }
        public long SurveyorId { get; set; }
        public long RowVersion { get; set; }
        public long AssignmentId { get; set; }
        public bool InActive { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Surveyor Surveyor { get; set; }
    }
}
