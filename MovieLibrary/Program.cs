public interface IFilm
{
    string? Title { get; set; }
    string? Director { get; set; }
    int Date { get; set; }
}
public interface IFilmLibrary
{
    void AddFlim(IFilm film);
    void RemoveFlim(string title);
    List<IFilm> GetFlim();
    List<IFilm> SearchFilm(string query);
    int GetTotalFilmCount();
}
public class Film : IFilm
{
    public string? Title { get; set; }
    public string? Director { get; set; }
    public int Date { get; set; }

    public Film()
    {

    }
    public Film(string title, string director, int date)
    {
        Title = title;
        Director = director;
        Date = date;
    }
}
public class FilmLib : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();
    public void AddFlim(IFilm film)
    {
        _films.Add(film);
    }
    public void RemoveFlim(string title)
    {
        var Title = _films.FirstOrDefault(s => s.Title.Equals(title));

        if (Title != null)
        {
            _films.Remove(Title);
        }
    }
    public List<IFilm> GetFlim()
    {
        return _films;
    }
    public List<IFilm> SearchFilm(string query)
    {
        return _films
                     .Where(s =>
                     s.Director.Contains(query) ||
                     s.Title.Contains(query)
                     ).ToList();
    }
    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}
public class Program
{
    public static void Main()
    {
        FilmLib f = new FilmLib();

        Console.WriteLine("Enter the number of Movies");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the Title");
            string? title = Console.ReadLine();

            Console.WriteLine("Enter the Director");
            string? director = Console.ReadLine();

            Console.WriteLine("Enter the Date (Year)");
            int year = int.Parse(Console.ReadLine());

            f.AddFlim(new Film(title, director, year));
        }

        int totalFilm = f.GetTotalFilmCount();
        Console.WriteLine("Total Films : " + totalFilm);

        Console.WriteLine("Which movie you want search!");
        string? query = Console.ReadLine();

        List<IFilm> films = f.SearchFilm(query);
        foreach (var i in films)
        {
            Console.WriteLine($"Name of the Movie : {i.Title} and Director : {i.Director}");
        }

        Console.WriteLine("Write the Title of Movie to Remove it!");
        string? titleToRemove = Console.ReadLine();
        f.RemoveFlim(titleToRemove);

        Console.WriteLine("\nRemaining Movies:");
        List<IFilm> films1 = f.GetFlim();
        foreach (var i in films1)
        {
            Console.WriteLine($"Name of the Movie : {i.Title} and Director : {i.Director}");
        }
    }
}
