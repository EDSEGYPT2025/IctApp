namespace IctApp.Models
{
    // نموذج لتمثيل مصطلح واحد في المسرد
    public class GlossaryTerm
    {
        public int Id { get; set; }
        public string Term { get; set; } // المصطلح نفسه
        public string Definition { get; set; } // تعريف المصطلح
    }
}
