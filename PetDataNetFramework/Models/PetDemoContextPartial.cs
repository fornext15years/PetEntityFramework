using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Interception;
using PetDataNetFramework.Log;

namespace PetDataNetFramework.Models
{
    public partial class PetDemoEntities : DbContext
    {
        public PetDemoEntities(string connectionString)
            :base(connectionString)
        {
            //this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
            //DbInterception.Add(new EFCommandInterceptor());
            
        }
    }
}
