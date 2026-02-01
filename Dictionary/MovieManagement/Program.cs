public class Movie
{
    public string? Name{get; set;}
    public string? Genere{get; set;}
    public int Rating{get; set;}

    public Movie(){}
}
public class MovieUtility
{
    public static SortedDictionary<int, Movie> movieDetails = new SortedDictionary<int, Movie>();
    public static int Count = 1;
    public void AddMovieDetails(string name, string genre, int rating)
    {
        Movie movie = new Movie
        {
            Name = name,
            Genere = genre,
            Rating = rating  
        };

       
        movieDetails.Add(Count, movie);
        Count++;
    }
    public SortedDictionary<string, List<Movie>> GroupMoviesByGenre()
    {
        SortedDictionary<string, List<Movie>> result = new SortedDictionary<string, List<Movie>>();
        foreach(var item in movieDetails)
        {
            var movieGenre = item.Value;
            if (!result.ContainsKey(movieGenre.Genere))
            {
                result[movieGenre.Genere] = new List<Movie>();
            }
            result[movieGenre.Genere].Add(item.Value); 
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        MovieUtility m = new MovieUtility();

        while (true)
        {
            Console.WriteLine("\n1. Add Movie Details");
            Console.WriteLine("2. Group Movies By Genre");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 3)
            {
                Console.WriteLine("Exiting application...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Movie Name: ");
                    string name = Console.ReadLine()!;

                    Console.Write("Enter Genre: ");
                    string genre = Console.ReadLine()!;

                    Console.Write("Enter Rating: ");
                    int rating = int.Parse(Console.ReadLine()!);

                    m.AddMovieDetails(name, genre, rating);
                    Console.WriteLine("Movie added successfully!");
                    break;

                case 2:
                    SortedDictionary<string, List<Movie>> result =
                        m.GroupMoviesByGenre();

                    foreach (var item in result)
                    {
                        Console.WriteLine($"\nGenre: {item.Key}");
                        foreach (var movie in item.Value)
                        {
                            Console.WriteLine($"Name: {movie.Name}");
                            Console.WriteLine($"Rating: {movie.Rating}");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
