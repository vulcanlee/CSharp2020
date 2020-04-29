using System;
using DatabaseModel.Models;

namespace DBEntityFrameworkCoreByStandard
{
    class Program
    {
        static void Main(string[] args)
        {
            ContosoUniversityContext ContosoUniversityContext = new ContosoUniversityContext();
            foreach (var item in ContosoUniversityContext.Course)
            {
                Console.WriteLine($"{item.Title}");
            }
        }
    }
}
