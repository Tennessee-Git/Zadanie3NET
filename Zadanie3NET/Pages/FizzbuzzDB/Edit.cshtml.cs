using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadanie3NET.Forms;

namespace Zadanie3NET.Pages.FizzbuzzDB
{
    public class EditModel : PageModel
    {
        private readonly Zadanie3NET.Forms.FizzbuzzContext _context;

        public EditModel(Zadanie3NET.Forms.FizzbuzzContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fizzbuzz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FizzbuzzExists(Fizzbuzz.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FizzbuzzExists(int id)
        {
            return _context.Fizzbuzzes.Any(e => e.Id == id);
        }
    }
}
