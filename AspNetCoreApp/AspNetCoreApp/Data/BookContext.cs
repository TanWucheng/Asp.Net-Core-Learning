using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Data
{
    public class BookContext : DbContext
    {
        public BookContext (DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Book> Book { get; set; }
    }
}
