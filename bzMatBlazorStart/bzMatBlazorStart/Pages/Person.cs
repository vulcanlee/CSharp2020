using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bzMatBlazorStart.Pages
{
    public class Person
    {
        [Required(ErrorMessage = "名 欄位必須要輸入值")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "姓 欄位必須要輸入值")]
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
    }
}
