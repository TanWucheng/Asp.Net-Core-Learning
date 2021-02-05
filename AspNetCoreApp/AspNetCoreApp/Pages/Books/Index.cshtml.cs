using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreApp.Models;
using AspNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookContext _context;

        public IndexModel(BookContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchKey { get; set; }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            var books = _context.Book.AsQueryable();
            if (!string.IsNullOrEmpty(SearchKey))
            {
                books = books.Where(x => x.Title.Contains(SearchKey));
            }
            Book = await books.ToListAsync();
        }
    }
}
