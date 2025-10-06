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
    public class StageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public StageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Stage? CurrentStage { get; set; }
        public IList<Grade> Grades { get; set; } = new List<Grade>();

        public async Task<IActionResult> OnGetAsync(int stageId)
        {
            CurrentStage = await _context.Stages.FindAsync(stageId);
            if (CurrentStage == null)
            {
                return NotFound();
            }

            Grades = await _context.Grades.Where(g => g.StageId == stageId).ToListAsync();

            return Page();
        }
    }
}

