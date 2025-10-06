using IctApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IctApp.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties for statistics
        public int TotalUnits { get; set; }
        public int TotalLessons { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalGlossaryTerms { get; set; }

        // Property for chart data
        public string ChartDataJson { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Calculate statistics
            TotalUnits = await _context.Units.CountAsync();
            TotalLessons = await _context.Lessons.CountAsync();
            TotalQuestions = await _context.QuizQuestions.CountAsync();
            TotalGlossaryTerms = await _context.GlossaryTerms.CountAsync();

            // Prepare data for the chart
            var questionsPerUnit = await _context.Units
                .Include(u => u.QuizQuestions)
                .OrderBy(u => u.Id)
                .Select(u => new {
                    UnitTitle = u.Title,
                    QuestionCount = u.QuizQuestions.Count
                })
                .ToListAsync();

            var chartLabels = questionsPerUnit.Select(u => u.UnitTitle).ToList();
            var chartData = questionsPerUnit.Select(u => u.QuestionCount).ToList();

            ChartDataJson = JsonSerializer.Serialize(new { labels = chartLabels, data = chartData });

            return Page();
        }
    }
}

