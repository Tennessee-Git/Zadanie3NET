using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie3NET.Forms
{
    public class Fizzbuzz
    {
        public Fizzbuzz()
        {
            Input = 0;
            Output = "";
            Time = DateTime.Now;
        }

        [Range(1, 1000)]
        [Required(ErrorMessage = "Pole wymagane!")]
        public int Input { get; set; }

        public string Output { get; set; }

        public DateTime Time { get; set; }

        public void DefineOutputAndTime()
        {
            
            if (Input % 3 == 0)
                Output += "Fizz";
            if (Input % 5 == 0)
                Output += "Buzz";
            if(Output == "")
                Output = Input.ToString();
            Time = DateTime.Now;
        }
    }
}
