using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IctApp.Pages.Learn
{
    public class GradeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public GradeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Unit> Units { get; set; } = new List<Unit>();
        public Unit? SelectedUnit { get; set; }
        public Lesson? SelectedLesson { get; set; }
        public int CurrentGradeId { get; set; }
        public string CurrentGradeTitle { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int gradeId, int? unitId, int? lessonId)
        {
            var grade = await _context.Grades.FindAsync(gradeId);
            if (grade == null) return NotFound();

            CurrentGradeId = gradeId;
            CurrentGradeTitle = grade.Title;

            Units = await _context.Units
                .Where(u => u.GradeId == gradeId)
                .Include(u => u.Lessons)
                .Include(u => u.QuizQuestions)
                .OrderBy(u => u.Id)
                .ToListAsync();

            if (unitId.HasValue)
            {
                SelectedUnit = Units.FirstOrDefault(u => u.Id == unitId.Value);
            }

            if (lessonId.HasValue && SelectedUnit != null)
            {
                SelectedLesson = SelectedUnit.Lessons.FirstOrDefault(l => l.Id == lessonId.Value);
            }
            return Page();
        }
    }
}

