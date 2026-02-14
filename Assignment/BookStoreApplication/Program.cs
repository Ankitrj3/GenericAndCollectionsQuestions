public class Book
{
    public string? Id{get; set;}
    public string? Title{get; set;}
    public int Price{get; set;}
    public int Stock{get; set;}

    public Book(){}
    public Book(string id, string title, int price, int stock)
    {
        Id = id;
        Title = title;
        Price = price;
        Stock = stock;
    }
}
public class BookUtility
{
    private Book book;
    public BookUtility(Book book)
    {
        this.book = book;
    }
    public void GetBookDetails()
    {
        Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");
    }
    public void UpdateBookPrice(int newPrice)
    {
        book.Price = newPrice;
        Console.WriteLine($"Updated Price: {book.Price}");
    }
    public void UpdateBookStock(int newStock)
    {
        book.Stock = newStock;   
        Console.WriteLine($"Updated Stock: {book.Stock}");
    }
}
public class Program
{
    public static void Main()
    {
        string? str = Console.ReadLine();
        string [] strArr = str.Split(' ');
        string? id = strArr[0];
        string? title = strArr[1];
        int price = int.Parse(strArr[2]);
        int stock = int.Parse(strArr[3]);

        Book b = new Book(id,title,price,stock);
        BookUtility bookUtility = new BookUtility(b);

        while (true)
        {
            string? choice = Console.ReadLine();
            if(choice == "1")
            {
                bookUtility.GetBookDetails();
            }else if(choice == "2")
            {
                int price1 = int.Parse(Console.ReadLine());
                bookUtility.UpdateBookPrice(price1);
            }else if(choice == "3")
            {
                int stock1 = int.Parse(Console.ReadLine());
                bookUtility.UpdateBookStock(stock1);
            }else if(choice == "4")
            {
                break;
            }
        }
    }
} 