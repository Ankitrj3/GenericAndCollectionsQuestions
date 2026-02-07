// Case Study: Movie Library Management System
 
// 1. Project Overview
// Objective:
// Develop a C# application for managing a movie library.
// The system should allow users to add movies, remove movies, search movies, and retrieve movie details using object-oriented principles such as interfaces, classes, and collections.
 
// 2. Functional Requirements
// A. Interface Specification (IFilm Interface)
// Create an interface named IFilm with the following properties:
// Member Type	Name	Data Type	Description
// Property	Title	string	Title of the film
 
// B. Data Model (Film Class)
// Create a class named Film that implements the IFilm interface.
// The class must contain the following public properties:
// Member Type	Name	Data Type	Description
// Property	Title	string	Title of the film
// Property	Director	string	Director of the film
// Property	Year	int	Year the film was released
 
// C. Library Management (IFilmLibrary Interface)
// Create an interface named r that defines the following methods:
// Method Name	Return Type	Description
// AddFilm(IFilm film)	void	Adds a film to the library
// RemoveFilm(string title)	void	Removes a film by title
// GetFilms()	List<IFilm>	Returns all films
// SearchFilms(string query)	List<IFilm>	Searches films by title or director
// GetTotalFilmCount()	int	Returns the total number of films
 
// D. Film Library Implementation (FilmLibrary Class)
// Create a class named FilmLibrary that implements the IFilmLibrary interface.
// Internal Data Structure
// •	Maintain a private List<IFilm> _films to store films.
 
// 3. Business Logic Rules
// AddFilm(IFilm film)
// •	Adds the provided film object to the _films list.
// RemoveFilm(string title)
// •	Removes a film from _films if a film with the specified title exists.
// GetFilms()
// •	Returns the complete list of films in the library.
// SearchFilms(string query)
// •	Searches for films where:
// o	Title contains the query string OR
// o	Director contains the query string
// •	Returns a list of matching films.
// GetTotalFilmCount()
// •	Returns the total number of films present in the library.
 
// 4. Example Scenario
// •	Two film objects are created with:
// o	Title
// o	Director
// o	Year
// •	These films are added to the film library.
// •	The user can:
// o	View all films
// o	Search by title or director
// o	Remove a film
// o	Get the total number of films
 
// 5. Constraints & Guidelines
// •	All interfaces, classes, properties, and methods must be public
// •	Use List<T> for storing films
// •	Follow interface-based design
// •	Implement proper object-oriented principles
// •	Code must compile in C#
// •	No unnecessary logic outside defined responsibilities
 
// 6. Learning Outcome
// Through this case study, learners will understand:
// •	Interface implementation in C#
// •	Class-to-interface relationships
// •	Collection handling using List<T>
// •	Search and filtering logic
// •	Separation of concerns in application design

// Sample Output (5 Test Cases)
// TEST CASE 1: Adding films
// Films added successfully

// TEST CASE 2: Displaying all films
// Inception | Christopher Nolan | 2010
// Interstellar | Christopher Nolan | 2014
// Titanic | James Cameron | 1997

// TEST CASE 3: Search films by director 'Nolan'
// Inception | Christopher Nolan
// Interstellar | Christopher Nolan

// TEST CASE 4: Removing film 'Titanic'
// Remaining films:
// Inception
// Interstellar

// TEST CASE 5: Total film count
// Total Films: 2


// TEST CASE 1: Adding films
// Films added successfully

// TEST CASE 2: Displaying all films
// Inception | Christopher Nolan | 2010
// Interstellar | Christopher Nolan | 2014
// Titanic | James Cameron | 1997

// TEST CASE 3: Search films by director 'Nolan'
// Inception | Christopher Nolan
// Interstellar | Christopher Nolan

// TEST CASE 4: Removing film 'Titanic'
// Remaining films:
// Inception
// Interstellar

// TEST CASE 5: Total film count
// Total Films: 2

public interface IFilm
{
    string? Title{get; set;}
}
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}
public class Film : IFilm
{
    public string? Title{get; set;}
    public string? Director{get; set;}
    public int Year{get; set;}    
    public Film(){}
    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        if (_films.Any(s => s.Title == film.Title))
        {
            Console.WriteLine("Film Already Exist");
            return;
        }
        _films.Add(film);
    }
    public void RemoveFilm(string title)
    {
        var film = _films.FirstOrDefault(s => s.Title == title);
        if(film != null)
        {
            _films.Remove(film);
        }
        Console.WriteLine("Film is Not Exist");
    }
    public List<IFilm> GetFilms()
    {
        return _films;
    }
    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> result = new List<IFilm>();
        foreach(var item in _films)
        {
            Film i = (Film)item;
            if(i.Title != null && i.Title == query || i.Director != null && i.Director == query)
            {
                result.Add(i);
            }
        }
        return result;
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
        IFilmLibrary library = new FilmLibrary();

        // TEST CASE 1: Adding films
        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
        library.AddFilm(new Film("Titanic", "James Cameron", 1997));
        Console.WriteLine("Films added successfully");

        // TEST CASE 2: Displaying all films
        foreach (var film in library.GetFilms())
        {
            Film f = (Film)film;
            Console.WriteLine($"{f.Title} | {f.Director} | {f.Year}");
        }

        // TEST CASE 3: Search films by director 'Nolan'
        var searchResults = library.SearchFilms("Nolan");
        foreach (var film in searchResults)
        {
            Film f = (Film)film;
            Console.WriteLine($"{f.Title} | {f.Director}");
        }

        // TEST CASE 4: Removing film 'Titanic'
        library.RemoveFilm("Titanic");
        Console.WriteLine("Remaining films:");
        foreach (var film in library.GetFilms())
        {
            Film f = (Film)film;
            Console.WriteLine(f.Title);
        }

        // TEST CASE 5: Total film count
        Console.WriteLine($"Total Films: {library.GetTotalFilmCount()}");
    }
}
