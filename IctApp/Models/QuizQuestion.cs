using System.Collections.Generic;

namespace IctApp.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Explanation { get; set; } // تم إضافة هذه الخاصية
        public List<QuizOption> Options { get; set; } = new List<QuizOption>();

        // Foreign Key for Unit
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}

