using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IctApp.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

        // This is the required foreign key property
        public int GradeId { get; set; }
        public Grade? Grade { get; set; }
    }
}

