using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreApp.Models;

namespace AspNetCoreApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Data.BookContext _context;

        public IndexModel(Data.BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
