using System.Collections.Generic;
using AspNetCoreMvcApp.Models;

namespace AspNetCoreMvcApp.ViewModels
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }

        public Book Book { get; set; }
    }
}