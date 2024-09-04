using Library.API.Models;

namespace Library.API.Services;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book? GetBookById(int id);
    // Наверное лучше заменить на другие классы Book в методах Create и Update
    Book? CreateBook(Book book);
    void UpdateBook(Book book);
    bool DeleteBook(int id);
}