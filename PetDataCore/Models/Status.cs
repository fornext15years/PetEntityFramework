using System;
using System.Collections.Generic;

namespace PetDataCore.Models
{
    public partial class Status
    {
        public Status()
        {
            Activity = new HashSet<Activity>();
        }

        public int Idx { get; set; }
        public string ActivityStatus { get; set; }
        public long RowVersion { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}
