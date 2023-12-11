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
    public class DetailsModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
