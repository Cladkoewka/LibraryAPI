using Library.API.Models;
using Library.API.Repository.Interfaces;

namespace Library.API.Services.Implimentations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public Book? GetBookById(int id)
    {
        return _bookRepository.GetById(id);
    }

    public Book? CreateBook(Book book)
    {
        return _bookRepository.Add(book);
    }

    public void UpdateBook(Book book)
    {
        _bookRepository.Update(book);
    }

    public bool DeleteBook(int id)
    {
        return _bookRepository.Delete(id);
    }
}