using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zadanie3NET.Forms;

namespace Zadanie3NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Fizzbuzz Fizzbuzz { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Fizzbuzz.DefineOutputAndTime();
                HttpContext.Session.SetString("SessionFizzbuzz", JsonConvert.SerializeObject(Fizzbuzz));
                ViewData["result"] = $"Otrzymano: {Fizzbuzz.Output}";
            }
            return Page();
        }
    }
}
