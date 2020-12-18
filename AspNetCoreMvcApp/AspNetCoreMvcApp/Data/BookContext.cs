using AspNetCoreMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcApp.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}