using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Pages.Sauces
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Sauce Sauce { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sauce == null)
            {
                return NotFound();
            }

            var sauce = await _context.Sauce.FirstOrDefaultAsync(m => m.SauceId == id);

            if (sauce == null)
            {
                return NotFound();
            }
            else 
            {
                Sauce = sauce;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sauce == null)
            {
                return NotFound();
            }
            var sauce = await _context.Sauce.FindAsync(id);

            if (sauce != null)
            {
                Sauce = sauce;
                _context.Sauce.Remove(Sauce);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
