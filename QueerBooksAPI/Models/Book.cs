using System;

namespace QueerBooksAPI.Models;

public class Book : BaseEntity
{
    public long BookId { get; set; }
    public string Title { get; set; }
    public ICollection<Author> Author { get; set; }
    public string Blurb { get; set; }
}

