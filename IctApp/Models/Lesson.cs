namespace IctApp.Models
{
    // يمثل درساً داخل وحدة
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; // محتوى الدرس بصيغة HTML
        public int Order { get; set; } // لترتيب الدروس داخل الوحدة

        public int UnitId { get; set; }
        public Unit? Unit { get; set; }

        public QuizQuestion? QuizQuestion { get; set; }
    }
}
