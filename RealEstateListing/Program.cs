public class RealEstateListing
{
    public int Id{get; set;}
    public string? Title{get; set;}
    public string? Description{get; set;}
    public int Price{get; set;}
    public string? Location{get; set;}

    public RealEstateListing(){}
    public RealEstateListing(int id, string title, string description, int price, string location)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }
}
public class RealEstateApp
{
    private List<RealEstateListing> _realStateData = new List<RealEstateListing>();
    public void AddListing(RealEstateListing realEstateListing)
    {
        _realStateData.Add(realEstateListing);
    }
    public void RemoveEstateListing(int id)
    {
        var removeEstate = _realStateData
                           .FirstOrDefault(s => s.Id.Equals(id));
        if(removeEstate != null)
        {
            _realStateData.Remove(removeEstate);
        }
    }
    public List<RealEstateListing> GetListings()
    {
        return _realStateData;
    }
    public List<RealEstateListing> GetListingByLocation(string location)
    {
        return _realStateData.Where(s => s.Location == null &&
                              s.Location.Equals(location))
                             .ToList();
    }
    public List<RealEstateListing> GetListingByPriceRange(int min_price, int maxprice)
    {
        return _realStateData
               .Where(s => s.Price>=min_price && s.Price<=maxprice)
               .ToList();
    }
    public void UpdateListing(RealEstateListing realEstateListing)
    {
        foreach(var i in _realStateData)
        {
            if(i.Id == realEstateListing.Id)
            {
                i.Title = realEstateListing.Title;
                i.Description = realEstateListing.Description;
                i.Price = realEstateListing.Price;
                i.Location = realEstateListing.Location;
                break;
            }
        }
    }
}
public class Program
{
    public static void Main()
    {
        RealEstateApp app = new RealEstateApp();

        Console.WriteLine("Enter number of properties:");
        int n = int.Parse(Console.ReadLine());

        // ADD LISTINGS
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter Property Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Price:");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Location:");
            string location = Console.ReadLine();

            app.AddListing(new RealEstateListing(id, title, description, price, location));
        }

        // DISPLAY ALL
        Console.WriteLine("\n--- All Listings ---");
        Display(app.GetListings());

        // SEARCH BY LOCATION
        Console.WriteLine("\nEnter location to search:");
        string searchLocation = Console.ReadLine();
        Display(app.GetListingByLocation(searchLocation));

        // SEARCH BY PRICE RANGE
        Console.WriteLine("\nEnter Min Price:");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Max Price:");
        int max = int.Parse(Console.ReadLine());
        Display(app.GetListingByPriceRange(min, max));

        // UPDATE LISTING
        Console.WriteLine("\nEnter Id to update:");
        int updateId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter New Title:");
        string newTitle = Console.ReadLine();

        Console.WriteLine("Enter New Description:");
        string newDesc = Console.ReadLine();

        Console.WriteLine("Enter New Price:");
        int newPrice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter New Location:");
        string newLocation = Console.ReadLine();

        app.UpdateListing(new RealEstateListing(updateId, newTitle, newDesc, newPrice, newLocation));

        Console.WriteLine("\n--- After Update ---");
        Display(app.GetListings());

        // REMOVE LISTING
        Console.WriteLine("\nEnter Id to remove:");
        int removeId = int.Parse(Console.ReadLine());
        app.RemoveEstateListing(removeId);

        Console.WriteLine("\n--- After Removal ---");
        Display(app.GetListings());
    }

    // Helper method
    static void Display(List<RealEstateListing> listings)
    {
        if (listings.Count == 0)
        {
            Console.WriteLine("No listings found.");
            return;
        }

        foreach (var l in listings)
        {
            Console.WriteLine($"Id:{l.Id}, Title:{l.Title}, Price:{l.Price}, Location:{l.Location}");
        }
    }
}
