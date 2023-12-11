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
    public class IndexModel : PageModel
    {
        private readonly FinalProject_skinsinger.Data.ApplicationDbContext _context;

        public IndexModel(FinalProject_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sauce> Sauce { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sauce != null)
            {
                Sauce = await _context.Sauce.ToListAsync();
            }
        }
    }
}
