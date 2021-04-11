using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zadanie3NET.Forms;

namespace Zadanie3NET.Pages.FizzbuzzDB
{
    public class IndexModel : PageModel
    {
        private readonly Zadanie3NET.Forms.FizzbuzzContext _context;

        public IndexModel(Zadanie3NET.Forms.FizzbuzzContext context)
        {
            _context = context;
        }

        public IList<Fizzbuzz> Fizzbuzz { get;set; }

        public async Task OnGetAsync()
        {
            Fizzbuzz = await _context.Fizzbuzzes.ToListAsync();
        }
    }
}
