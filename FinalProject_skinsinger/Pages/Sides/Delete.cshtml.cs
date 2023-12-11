using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject_skinsinger.Data;
using FinalProject_skinsinger.Data.Models;

namespace FinalProject_skinsinger.Pages.Sides
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public side side { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.side == null)
            {
                return NotFound();
            }

            var side = await _context.side.FirstOrDefaultAsync(m => m.SideId == id);

            if (side == null)
            {
                return NotFound();
            }
            else 
            {
                side = side;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.side == null)
            {
                return NotFound();
            }
            var side = await _context.side.FindAsync(id);

            if (side != null)
            {
                side = side;
                _context.side.Remove(side);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
