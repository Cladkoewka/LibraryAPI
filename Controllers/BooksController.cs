using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    // GET: api/books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }
    
    // GET: api/books/{id}
    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
        var book = _bookService.GetBookById(id);
        
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
    
    // POST: api/books
    [HttpPost]
    public ActionResult<Book> CreateBook(Book book) // Добавить валидацию модели
    {
        var createdBook = _bookService.CreateBook(book);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateBook(int id, Book book) // Добавить валидацию модели
    {
        var bookToUpdate = _bookService.GetBookById(id);
        if (bookToUpdate == null)
        {
            return NotFound();
        }
        
        _bookService.UpdateBook(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBook(int id)
    {
        var result = _bookService.DeleteBook(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}