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
    public class DetailsModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
