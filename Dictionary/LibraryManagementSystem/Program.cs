// Question 1: Library Management System
// Scenario: A library needs a console application to manage books and categorize them by genre.
// Requirements:
// csharp
// // In class Book, implement:
// // - string Title
// // - string Author
// // - string Genre
// // - int PublicationYear

// // In class LibraryUtility:
// public void AddBook(string title, string author, string genre, int year)
// // Adds book with auto-incremented ID

// public SortedDictionary<string, List<Book>> GroupBooksByGenre()
// // Groups books by genre alphabetically

// public List<Book> GetBooksByAuthor(string author)
// // Returns all books by specific author

// public int GetTotalBooksCount()
// // Returns total number of books
// Sample Use Cases:
// 1.	Add Fiction, Non-Fiction, Mystery books
// 2.	Display books grouped by genre
// 3.	Search books by specific author
// 4.	Show statistics (total books, books per genre)

public class Book
{
    public string? Title{get; set;}
    public string? Author{get; set;}
    public string? Genre{get; set;}
    public int PublicationYear{get; set;}

    public Book(){}
}
public class LibraryUtility
{
    public LibraryUtility(){}
    public static SortedDictionary<int, Book> bookDetails = new SortedDictionary<int, Book>();
    public static int Id = 1;
    public void AddBook(string title, string author, string genre, int year)
    {
        Book book = new Book()
        {
            Title = title,
            Author = author,
            Genre = genre,
            PublicationYear = year  
        };
        bookDetails.Add(Id, book);
        Id++;
    }
    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string, List<Book>> result = new SortedDictionary<string, List<Book>>();
        foreach(var item in bookDetails)
        {
            Book book = item.Value;
            if (!result.ContainsKey(book.Genre))
            {
                result[book.Genre] = new List<Book>();
            }
            result[book.Genre].Add(book);
        }
        return result;
    }
    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();
        foreach(var item in bookDetails)
        {
            Book book = item.Value;
            if(book.Author == author)
            {
                result.Add(book);
            }
        }
        return result;
    }
    public int GetTotalBooksCount()
    {
        int count = 0;
        foreach(var i in bookDetails)
        {
            count++;
        }
        return count;
    }
    public SortedDictionary<string,int> GetTotalBooksCountByGenre()
    {
        SortedDictionary<string, int> result = new SortedDictionary<string, int>();
        foreach(var i in bookDetails)
        {
            Book book = i.Value;
            if (!result.ContainsKey(book.Genre))
            {
                result[book.Genre] = 0;
            }
            result[book.Genre]++;
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        LibraryUtility library = new LibraryUtility();

        while (true)
        {
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. Display Books Grouped By Genre");
            Console.WriteLine("3. Search Books By Author");
            Console.WriteLine("4. Show Statistics");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 5)
            {
                Console.WriteLine("Exiting application...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine()!;

                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine()!;

                    Console.Write("Enter Genre: ");
                    string genre = Console.ReadLine()!;

                    Console.Write("Enter Publication Year: ");
                    int year = int.Parse(Console.ReadLine()!);

                    library.AddBook(title, author, genre, year);
                    Console.WriteLine("Book added successfully!");
                    break;

                case 2:
                    var groupedBooks = library.GroupBooksByGenre();

                    foreach (var item in groupedBooks)
                    {
                        Console.WriteLine($"\nGenre: {item.Key}");
                        foreach (var book in item.Value)
                        {
                            Console.WriteLine(
                                $"{book.Title} - {book.Author} ({book.PublicationYear})");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Author Name: ");
                    string searchAuthor = Console.ReadLine()!;

                    List<Book> booksByAuthor =
                        library.GetBooksByAuthor(searchAuthor);

                    if (booksByAuthor.Count == 0)
                    {
                        Console.WriteLine("No books found for this author.");
                    }
                    else
                    {
                        foreach (var book in booksByAuthor)
                        {
                            Console.WriteLine(
                                $"{book.Title} - {book.Genre} ({book.PublicationYear})");
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");

                    var genreCount = library.GetTotalBooksCountByGenre();
                    foreach (var item in genreCount)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
