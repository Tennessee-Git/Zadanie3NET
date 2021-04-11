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
    public class DetailsModel : PageModel
    {
        private readonly Zadanie3NET.Forms.FizzbuzzContext _context;

        public DetailsModel(Zadanie3NET.Forms.FizzbuzzContext context)
        {
            _context = context;
        }

        public Fizzbuzz Fizzbuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fizzbuzz = await _context.Fizzbuzzes.FirstOrDefaultAsync(m => m.Id == id);

            if (Fizzbuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
