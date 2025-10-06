using System.Collections.Generic;
using System.Diagnostics;

namespace IctApp.Models
{
    public class Stage
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}

