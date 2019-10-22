using System;
using System.Collections.Generic;

namespace PetDataCore.Models
{
    public partial class Activity
    {
        public long Idx { get; set; }
        public string Name { get; set; }
        public string BbpactivityId { get; set; }
        public long RowVersion { get; set; }
        public long ActivityTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public DateTime? ScheduleDueDate { get; set; }
        public int Unannounced { get; set; }
        public int? StandardsVersion { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
