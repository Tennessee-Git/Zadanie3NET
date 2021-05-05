using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Zadanie3NET.Forms;

namespace Zadanie3NET.Pages
{
    [Authorize]
    public class Last_ResultModel : PageModel
    {
        [BindProperty]
        public Fizzbuzz Fizzbuzz { get; set; }

        public void OnGet()
        {
            var SessionFizzbuzz = HttpContext.Session.GetString("SessionFizzbuzz");
            if (SessionFizzbuzz != null)
                Fizzbuzz = JsonConvert.DeserializeObject<Fizzbuzz>(SessionFizzbuzz);
        }
    }
}
