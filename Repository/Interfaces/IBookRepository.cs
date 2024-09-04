using Library.API.Models;

namespace Library.API.Repository.Interfaces;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book? Add(Book book);
    void Update(Book book);
    bool Delete(int id);
}