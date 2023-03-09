using System;

namespace QueerBooksAPI.Models;

public class Author : BaseEntity
{
    public long AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Book> Books { get; set; }

}