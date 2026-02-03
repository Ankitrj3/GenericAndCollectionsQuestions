// 📘 Scenario
// A library wants a console-based application to manage book details such as
// title, author, and price, and also to group books based on author.

// 🛠️ Functionalities

// In class Program
// public static SortedDictionary<int, Book> bookDetails

// This sorted dictionary is already provided. It stores book details with a unique integer key.

// In class Book, implement the below properties
// string Title
// string Author
// int Price

// In class BookUtility, implement the below methods

// Method 1
// public void AddBookDetails(string title, string author, int price)

// Adds the book details to the dictionary.
// The key should be one more than the current count.

// Method 2
// public SortedDictionary<string, List<Book>> GroupBooksByAuthor()

// Groups books based on author.

// Menu:
// 1. Add Book Details
// 2. Group Books By Author
// 3. Exit

public class Book
{
    public string? Title{get; set;}
    public string? Author{get; set;}
    public int Price{get; set;}
    public Book(){}
}
public class BookUtility
{
    public static SortedDictionary<int, Book> bookDetails = new SortedDictionary<int, Book>();
    public static int Id = 1;
    public void AddBookDetails(string title, string author, int price)
    {
       Book book = new Book(){
            Title = title,
            Author = author,
            Price = price
       };
        if (!bookDetails.ContainsKey(Id))
        {
            bookDetails.Add(Id,book);
            Id++;
        }
    }
    public SortedDictionary<string, List<Book>> GroupBooksByAuthor()
    {
        SortedDictionary<string, List<Book>> res = new SortedDictionary<string, List<Book>>();
        foreach(var item in bookDetails)
        {
            Book book = item.Value;

            if (!res.ContainsKey(book.Author))
            {
                res[book.Author] = new List<Book>();
            }
            res[book.Author].Add(book);
        }
        return res;
    }
}
public class Program
{
    public static void Main()
    {
        BookUtility b = new BookUtility();

        while (true)
        {
            Console.WriteLine("1. Add Book Details");
            Console.WriteLine("2. Group Books By Author");
            Console.WriteLine("3. Exit");
            string? Choice = Console.ReadLine();
            int choice = int.Parse(Choice);
            if(choice == 3)
            {
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Title Name:");
                    string? title = Console.ReadLine();
                    Console.WriteLine("Enter Author Name:");
                    string? author = Console.ReadLine();
                    Console.WriteLine("Enter The Price");
                    string? Price = Console.ReadLine();
                    int price = int.Parse(Price);

                    b.AddBookDetails(title,author,price);
                    break;

                case 2:
                    SortedDictionary<string,List<Book>> result = b.GroupBooksByAuthor();

                    foreach(var item in result)
                    {
                        Console.WriteLine(item.Key);
                        foreach(var j in item.Value)
                        {
                            Console.WriteLine(j.Title);
                            Console.WriteLine(j.Price);
                        }
                    }
                    break;
            }
        }
    }
}