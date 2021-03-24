using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie3NET.Forms
{
    public class Fizzbuzz
    {
        [Range(1, 1000)]
        [Required(ErrorMessage = "Pole wymagane!")]
        [DataType(DataType.Text)]
        public int Input { get; set; }

        public string Output { get; set; }

        public DateTime Time { get; set; }

        public void DefineOutputAndTime()
        {
            if(Input % 15 == 0)
                Output = "Fizzbuzz";
            else if (Input % 3 == 0)
                Output = "Fizz";
            else if (Input % 5 == 0)
                Output = "Buzz";
            else
                Output = Input.ToString();
            Time = DateTime.Now;
        }
    }
}
