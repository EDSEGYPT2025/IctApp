using System.Collections.Generic;

namespace IctApp.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int StageId { get; set; }
        public Stage? Stage { get; set; }
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
}

