using Newtonsoft.Json;
using System;

namespace UseJsonNET
{
    public class MyJson
    {
        public int MyProperty { get; set; }
        public string MyString { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
