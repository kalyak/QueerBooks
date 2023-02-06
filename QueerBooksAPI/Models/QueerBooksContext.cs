using Microsoft.EntityFrameworkCore;

namespace QueerBooksAPI.Models;

public class QueerBooksContext : DbContext
{
    public QueerBooksContext(DbContextOptions<QueerBooksContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
}


