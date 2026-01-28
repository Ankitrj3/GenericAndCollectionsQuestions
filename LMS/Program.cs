using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public interface IBook
{
    int Id { get; set; }
    string? Title { get; set; }
    string? Author { get; set; }
    string? Category { get; set; }
    int Price { get; set; }
}

public class Book : IBook
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Category { get; set; }
    public int Price { get; set; }

    public Book() { }
    public Book(int id, string title, string author, string category, int price)
    {
        Id = id;
        Title = title;
        Author = author;
        Category = category;
        Price = price;
    }
}
public interface ILibrarySystem
{
    void AddBook(IBook book, int quantity);
    void RemoveBook(IBook book, int quantity);
    int CalculateTotal();
    List<(string, int)> CategoryTotalPrice();
    List<(string, int, int)> BooksInfo();
    List<(string, string, int)> CategoryAndAuthorWithCount();
}
public class LibrarySystem : ILibrarySystem
{
    private Dictionary<IBook,int> _book = new Dictionary<IBook, int>();
    public void AddBook(IBook book, int quantity)
    {
        if (_book.ContainsKey(book))
        {
            _book[book] += quantity;
        }
        else
        {
            _book.Add(book,quantity);
        }
    }
    public void RemoveBook(IBook book, int quantity)
    {
        if (!_book.ContainsKey(book))
        {
            return;
        }
        else
        {
            _book[book] -= quantity;
        }
        if(_book[book] <= 0)
        {
            _book.Remove(book);
        }
    }
    public int CalculateTotal()
    {
        return _book.Sum(s => s.Key.Price * s.Value);
    }
    public List<(string, int)> CategoryTotalPrice()
    {
        return _book
                    .GroupBy(s => s.Key.Category)
                    .Select(b => (b.Key ?? "", b.Sum(x => x.Key.Price * x.Value)))
                    .ToList();
    }
    public List<(string, int, int)> BooksInfo()
    {
        return _book
                    .Select(s=> (s.Key.Title ?? "", s.Value, s.Key.Price))
                    .ToList();
    }
    public List<(string, string, int)> CategoryAndAuthorWithCount()
    {
        return _book
                    .GroupBy(s => new {s.Key.Category, s.Key.Author})
                    .Select(g => (g.Key.Category ?? "", g.Key.Author ?? "", g.Sum(x => x.Value)))
                    .ToList();
    }
}