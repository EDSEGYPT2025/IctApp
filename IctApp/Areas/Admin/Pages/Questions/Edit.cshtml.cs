using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IctApp.Areas.Admin.Pages.Questions
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public QuizQuestion Question { get; set; } = new();

        [BindProperty]
        public int CorrectOptionId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var question = await _context.QuizQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (question == null) return NotFound();

            Question = question;
            CorrectOptionId = Question.Options.FirstOrDefault(o => o.IsCorrect)?.Id ?? 0;
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Title");
                return Page();
            }

            // Manually update IsCorrect for each option
            foreach (var option in Question.Options)
            {
                option.IsCorrect = (option.Id == CorrectOptionId);
                _context.Attach(option).State = EntityState.Modified;
            }

            _context.Attach(Question).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
