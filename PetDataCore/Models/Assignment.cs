using System;
using System.Collections.Generic;

namespace PetDataCore.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            SurveyorAssignmentRole = new HashSet<SurveyorAssignmentRole>();
        }

        public long Idx { get; set; }
        public long ActivityId { get; set; }
        public DateTime Created { get; set; }
        public long RowVersion { get; set; }
        public string ScopeOfEos { get; set; }
        public bool? EmailSent { get; set; }
        public DateTime? EmailSentDate { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ICollection<SurveyorAssignmentRole> SurveyorAssignmentRole { get; set; }
    }
}
