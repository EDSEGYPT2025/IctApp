using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IctApp.Areas.Admin.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IGrouping<string, QuizQuestion>> QuestionsByUnit { get; set; } = new List<IGrouping<string, QuizQuestion>>();

        public async Task OnGetAsync()
        {
            var questions = await _context.QuizQuestions
                .Include(q => q.Unit)
                .Include(q => q.Options)
                .OrderBy(q => q.Unit.Id)
                .ThenBy(q => q.Id)
                .ToListAsync();

            QuestionsByUnit = questions.GroupBy(q => q.Unit.Title);
        }
    }
}
