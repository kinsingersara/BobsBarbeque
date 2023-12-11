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

namespace FinalProject_skinsinger.Pages.Desserts
{
    public class EditModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public EditModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dessert Dessert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dessert == null)
            {
                return NotFound();
            }

            var dessert =  await _context.Dessert.FirstOrDefaultAsync(m => m.DessertId == id);
            if (dessert == null)
            {
                return NotFound();
            }
            Dessert = dessert;
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

            _context.Attach(Dessert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DessertExists(Dessert.DessertId))
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

        private bool DessertExists(int id)
        {
          return (_context.Dessert?.Any(e => e.DessertId == id)).GetValueOrDefault();
        }
    }
}
