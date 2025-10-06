using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IctApp.Areas.Admin.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public QuizQuestion Question { get; set; } = new();

        [BindProperty]
        public List<QuizOption> Options { get; set; } = new() { new(), new(), new() };

        [BindProperty]
        public int CorrectOptionIndex { get; set; }

        public void OnGet()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Title");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Title");
                return Page();
            }

            for (int i = 0; i < Options.Count; i++)
            {
                Options[i].IsCorrect = (i == CorrectOptionIndex);
            }

            Question.Options = Options;
            _context.QuizQuestions.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
