using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IctApp.Areas.Admin.Pages.Lessons
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IGrouping<string, Lesson>> LessonsByUnit { get; set; } = new List<IGrouping<string, Lesson>>();

        public async Task OnGetAsync()
        {
            var lessons = await _context.Lessons
                .Include(l => l.Unit)
                .OrderBy(l => l.Unit.Id)
                .ThenBy(l => l.Id)
                .ToListAsync();

            LessonsByUnit = lessons.GroupBy(l => l.Unit.Title);
        }
    }
}
