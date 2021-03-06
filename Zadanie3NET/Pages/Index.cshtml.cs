using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zadanie3NET.Forms;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Zadanie3NET.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Zadanie3NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzbuzzContext _context;

        [BindProperty]
        public Fizzbuzz Fizzbuzz { get; set; }
        public IList<Fizzbuzz> FizzbuzzList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FizzbuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        { }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.User.Identity.Name != null)
                    Fizzbuzz.UserName = HttpContext.User.Identity.Name;
                else
                    Fizzbuzz.UserName = null;

                Fizzbuzz.DefineOutputAndTime();
                HttpContext.Session.SetString("SessionFizzbuzz", JsonConvert.SerializeObject(Fizzbuzz));
                ViewData["result"] = $"Otrzymano: {Fizzbuzz.Output}";
                _context.Add(Fizzbuzz);
                _context.SaveChanges();
            }
            return Page();
        }
    }
}
