using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetDataNetFramework;
using PetDataNetFramework.Models;


namespace PetConsoleNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                var activities = db.Activities.ToList();

                
                foreach(var activity in activities)
                {
                    Console.WriteLine($"Activity[Id:{activity.Idx}, Name:{activity.Name}");
                }
            }
        }
    }
}
