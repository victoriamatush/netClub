using Microsoft.EntityFrameworkCore;


namespace Lib.Models
{
    public class LibContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public LibContext(DbContextOptions<LibContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
