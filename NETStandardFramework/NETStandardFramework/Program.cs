using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseJsonNET;

namespace NETStandardFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            MyJson myJson = new MyJson();
            var foo = myJson.ToJson();
            
        }
    }
}
