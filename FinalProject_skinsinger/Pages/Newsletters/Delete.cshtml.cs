using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Pages.Newsletters
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Newsletter Newsletter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Newsletter == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter.FirstOrDefaultAsync(m => m.NewsletterId == id);

            if (newsletter == null)
            {
                return NotFound();
            }
            else 
            {
                Newsletter = newsletter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Newsletter == null)
            {
                return NotFound();
            }
            var newsletter = await _context.Newsletter.FindAsync(id);

            if (newsletter != null)
            {
                Newsletter = newsletter;
                _context.Newsletter.Remove(Newsletter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
