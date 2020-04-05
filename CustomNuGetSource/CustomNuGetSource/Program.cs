using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomNuGetSource
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = Vulcan.ServiceSample.MonkeyData.Monkeys;
            foreach (var item in foo)
            {
                Console.WriteLine($"{item.Name}");
            }


            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
