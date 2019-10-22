using System;
using System.Linq;
using PetDataCore.Models;

namespace PetConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PetDemoContext())
            {
                var activities = db.Activity.ToList();


                foreach (var activity in activities)
                {
                    Console.WriteLine($"Activity[Id:{activity.Idx}, Name:{activity.Name}");
                }
            }
        }
    }
}
