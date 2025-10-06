using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IctApp.Areas.Admin.Pages.Units
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Unit> Units { get; set; } = new List<Unit>();

        public async Task OnGetAsync()
        {
            // Fetch all units and include their related Grade information to display the grade's title.
            Units = await _context.Units
                .Include(u => u.Grade)
                .ToListAsync();
        }
    }
}

