using System;
using System.Collections.Generic;

namespace PetDataCore.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activity = new HashSet<Activity>();
        }

        public long Idx { get; set; }
        public string Type { get; set; }
        public long RowVersion { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}
