using System;
using System.Collections.Generic;

namespace PetDataCore.Models
{
    public partial class Surveyor
    {
        public Surveyor()
        {
            SurveyorAssignmentRole = new HashSet<SurveyorAssignmentRole>();
        }

        public long Idx { get; set; }
        public string UserName { get; set; }
        public long RowVersion { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public virtual ICollection<SurveyorAssignmentRole> SurveyorAssignmentRole { get; set; }
    }
}
