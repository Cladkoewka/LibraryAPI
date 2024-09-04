using Library.API.Database;
using Library.API.Models;
using Library.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository.Implimentations;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Book> GetAll()
    {
        return _context.Books.ToList();
    }

    public Book? GetById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book? Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public void Update(Book book)
    {
        var bookToUpdate = _context.Books.FirstOrDefault(b => b.Id == book.Id);
        _context.Books.Remove(bookToUpdate);
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public bool Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) 
            return false;

        _context.Books.Remove(book);
        _context.SaveChanges();
        return true;

    }
}