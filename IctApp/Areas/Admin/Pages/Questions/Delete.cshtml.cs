using System.Threading.Tasks;
using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IctApp.Areas.Admin.Pages.Questions
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public QuizQuestion Question { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var question = await _context.QuizQuestions
                .Include(q => q.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (question == null) return NotFound();

            Question = question;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var question = await _context.QuizQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question != null)
            {
                // EF Core will handle cascading delete for options if configured
                _context.QuizQuestions.Remove(question);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
