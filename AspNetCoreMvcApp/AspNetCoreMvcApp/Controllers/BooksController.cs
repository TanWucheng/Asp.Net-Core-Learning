using System.Linq;
using AspNetCoreMvcApp.Data;
using AspNetCoreMvcApp.Models;
using AspNetCoreMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcApp.Controllers
{
    public class BooksController:Controller
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books =  _context.Set<Book>().AsEnumerable().ToList();
            var viewModel = new BookViewModel
            {
                Books = books
            };
            return View(viewModel);
        }
    }
}