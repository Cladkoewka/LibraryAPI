namespace Library.API.Models;

public class BookIssuance
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookID { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ReturnDate { get; set; }
}