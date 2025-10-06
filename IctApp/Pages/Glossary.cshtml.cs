using IctApp.Data;
using IctApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IctApp.Pages
{
    public class GlossaryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public GlossaryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GlossaryTerm> GlossaryTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            var terms = from t in _context.GlossaryTerms
                        select t;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                terms = terms.Where(t => t.Term.Contains(SearchTerm) || t.Definition.Contains(SearchTerm));
            }

            GlossaryTerms = await terms.OrderBy(t => t.Term).ToListAsync();
        }
    }
}
