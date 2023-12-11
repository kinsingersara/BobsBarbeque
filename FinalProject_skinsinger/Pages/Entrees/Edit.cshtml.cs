using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Pages.Entrees
{
    public class EditModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public EditModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entree Entree { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Entree == null)
            {
                return NotFound();
            }

            var entree =  await _context.Entree.FirstOrDefaultAsync(m => m.EntreeId == id);
            if (entree == null)
            {
                return NotFound();
            }
            Entree = entree;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Entree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntreeExists(Entree.EntreeId))
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

        private bool EntreeExists(int id)
        {
          return (_context.Entree?.Any(e => e.EntreeId == id)).GetValueOrDefault();
        }
    }
}
