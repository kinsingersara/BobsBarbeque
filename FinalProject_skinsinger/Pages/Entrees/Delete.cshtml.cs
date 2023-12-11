using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Pages.Entrees
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
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

            var entree = await _context.Entree.FirstOrDefaultAsync(m => m.EntreeId == id);

            if (entree == null)
            {
                return NotFound();
            }
            else 
            {
                Entree = entree;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Entree == null)
            {
                return NotFound();
            }
            var entree = await _context.Entree.FindAsync(id);

            if (entree != null)
            {
                Entree = entree;
                _context.Entree.Remove(Entree);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
