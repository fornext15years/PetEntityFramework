using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDataNetFramework
{
    public class PetDataConnectionStringBuilder
    {
        static EntityConnectionStringBuilder entityBuilder = null;
        static public string GetConnectionString()
        {
            if(entityBuilder == null)
            {
                var originalConnectionString = ConfigurationManager.ConnectionStrings["PetDemoEntities"].ConnectionString;
                entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
                var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
                var providerBuilder = factory.CreateConnectionStringBuilder();
                providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
                providerBuilder.Add("Password", Environment.GetEnvironmentVariable("PetDBPassword", EnvironmentVariableTarget.Machine));
                entityBuilder.ProviderConnectionString = providerBuilder.ToString();
            }

            return entityBuilder.ToString();
        }
    }
}
