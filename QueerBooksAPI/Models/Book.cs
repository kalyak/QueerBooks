using System;

namespace QueerBooksAPI.Models;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; }
    public List<Author> Author { get; set; }
    public string Blurb { get; set; }
}

