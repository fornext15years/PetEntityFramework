using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDataNetFramework.Models
{
    public partial class PetDemoEntities : DbContext
    {
        public PetDemoEntities(string connectionString)
            :base(connectionString)
        {
        }
    }
}
