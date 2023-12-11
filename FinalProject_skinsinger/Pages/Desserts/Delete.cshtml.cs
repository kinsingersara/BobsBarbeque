using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Pages.Desserts
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
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

            var dessert = await _context.Dessert.FirstOrDefaultAsync(m => m.DessertId == id);

            if (dessert == null)
            {
                return NotFound();
            }
            else 
            {
                Dessert = dessert;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dessert == null)
            {
                return NotFound();
            }
            var dessert = await _context.Dessert.FindAsync(id);

            if (dessert != null)
            {
                Dessert = dessert;
                _context.Dessert.Remove(Dessert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
