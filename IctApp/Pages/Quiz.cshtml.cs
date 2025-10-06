using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IctApp.Pages
{
    public class QuizModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public QuizModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties to hold quiz data
        public QuizQuestion? CurrentQuestion { get; set; }
        public int UnitId { get; set; }
        public int QuestionIndex { get; set; }
        public int TotalQuestions { get; set; }
        public int Score { get; set; }
        public bool IsQuizFinished { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int unitId, int questionIndex = 0, int score = 0)
        {
            UnitId = unitId;
            QuestionIndex = questionIndex;
            Score = score;

            var questions = await _context.QuizQuestions
                                        .Where(q => q.UnitId == unitId)
                                        .OrderBy(q => q.Id)
                                        .ToListAsync();

            TotalQuestions = questions.Count;

            if (questionIndex >= TotalQuestions)
            {
                IsQuizFinished = true;
                return Page();
            }

            CurrentQuestion = questions.Skip(questionIndex).FirstOrDefault();

            if (CurrentQuestion != null)
            {
                // Ensure options are loaded for the current question
                _context.Entry(CurrentQuestion)
                   .Collection(q => q.Options)
                   .Load();
            }


            if (CurrentQuestion == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCheckAnswerAsync([FromBody] AnswerModel data)
        {
            if (data == null) return BadRequest();

            var selectedOption = await _context.QuizOptions.FindAsync(data.OptionId);
            if (selectedOption == null) return NotFound();

            var question = await _context.QuizQuestions.FindAsync(selectedOption.QuizQuestionId);
            if (question == null) return NotFound();

            var correctOption = await _context.QuizOptions
                .FirstOrDefaultAsync(o => o.QuizQuestionId == selectedOption.QuizQuestionId && o.IsCorrect);

            if (correctOption == null) return NotFound();

            bool isCorrect = selectedOption.IsCorrect;

            return new JsonResult(new
            {
                isCorrect = isCorrect,
                correctOptionId = correctOption.Id,
                explanation = question.Explanation
            });
        }
    }

    public class AnswerModel
    {
        public int OptionId { get; set; }
    }
}

