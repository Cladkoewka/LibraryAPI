using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Database;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
    
    public DbSet<Book> Books { get; set; }
    
}