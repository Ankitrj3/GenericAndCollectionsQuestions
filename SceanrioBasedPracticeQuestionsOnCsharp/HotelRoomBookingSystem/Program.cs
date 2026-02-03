// Question 2: Hotel Room Booking System
// Scenario: A hotel needs to manage room bookings and categorize rooms by type.
// Requirements:
// csharp
// // In class Room:
// // - int RoomNumber
// // - string RoomType (Single/Double/Suite)
// // - double PricePerNight
// // - bool IsAvailable

// // In class HotelManager:
// public void AddRoom(int roomNumber, string type, double price)
// // Adds room if room number doesn't exist

// public Dictionary<string, List<Room>> GroupRoomsByType()
// // Groups available rooms by type

// public bool BookRoom(int roomNumber, int nights)
// // Books room if available, calculates total cost

// public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
// // Returns available rooms within price range
// Sample Use Cases:
// 1.	Add different room types with prices
// 2.	Display available rooms grouped by type
// 3.	Book a room for specific nights
// 4.	Find rooms within budget

public class Room
{
    public int RoomNumber{get; set;}
    public string? RoomType{get; set;}
    public double PricePerNight{get; set;}
    public bool IsAvailable{get; set;}
    public Room(){}
}
public class HotelManager
{
    public HotelManager(){}
    public static Dictionary<int, Room> roomDetails = new Dictionary<int, Room>();

    public void AddRoom(int roomNumber, string type, double price)
    {
        if (roomDetails.ContainsKey(roomNumber))
        {
            Console.WriteLine("Room Number Already Exist");
            return;
        }
        Room room = new Room()
        {
            RoomNumber = roomNumber,
            RoomType = type,
            PricePerNight = price,
            IsAvailable = true
        };
        roomDetails.Add(roomNumber,room);
        Console.WriteLine("Room Added SuccessFully");
    }
    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        Dictionary<string, List<Room>> result = new Dictionary<string, List<Room>>();
        foreach(var item in roomDetails)
        {
            var room = item.Value;
            if (!result.ContainsKey(room.RoomType))
            {
                result[room.RoomType] = new List<Room>();
            }
            result[room.RoomType].Add(room);
        }
        return result;
    }
    public bool BookRoom(int roomNumber, int nights)
    {
        if (!roomDetails.ContainsKey(roomNumber))
        {
            Console.WriteLine("Room Not Found");
            return false;
        }
        Room room = roomDetails[roomNumber];
        if (!room.IsAvailable)
        {
            Console.WriteLine("Room is already Booked");
            return false;
        }
        double totalCost = room.PricePerNight * nights;
        room.IsAvailable = false;

        Console.WriteLine($"Room booked successfully!");
        Console.WriteLine($"Total Cost: {totalCost}");

        return true;
    }
    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        List<Room> result = new List<Room>();
        foreach(var item in roomDetails)
        {
            var room = item.Value;
            if(room.IsAvailable && room.PricePerNight >= min && room.PricePerNight <= max)
            {
                result.Add(room);
            }
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        HotelManager hotel = new HotelManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Room");
            Console.WriteLine("2. Display Available Rooms Grouped By Type");
            Console.WriteLine("3. Book Room");
            Console.WriteLine("4. Find Available Rooms By Price Range");
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
                    Console.Write("Enter Room Number: ");
                    int roomNumber = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter Room Type (Single/Double/Suite): ");
                    string type = Console.ReadLine()!;

                    Console.Write("Enter Price Per Night: ");
                    double price = double.Parse(Console.ReadLine()!);

                    hotel.AddRoom(roomNumber, type, price);
                    break;

                case 2:
                    Dictionary<string, List<Room>> groupedRooms =
                        hotel.GroupRoomsByType();

                    if (groupedRooms.Count == 0)
                    {
                        Console.WriteLine("No available rooms.");
                        break;
                    }

                    foreach (var item in groupedRooms)
                    {
                        Console.WriteLine($"\nRoom Type: {item.Key}");
                        foreach (var room in item.Value)
                        {
                            Console.WriteLine(
                                $"Room No: {room.RoomNumber}, Price: {room.PricePerNight}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Room Number to Book: ");
                    int bookRoomNo = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter Number of Nights: ");
                    int nights = int.Parse(Console.ReadLine()!);

                    hotel.BookRoom(bookRoomNo, nights);
                    break;

                case 4:
                    Console.Write("Enter Minimum Price: ");
                    double min = double.Parse(Console.ReadLine()!);

                    Console.Write("Enter Maximum Price: ");
                    double max = double.Parse(Console.ReadLine()!);

                    List<Room> rooms =
                        hotel.GetAvailableRoomsByPriceRange(min, max);

                    if (rooms.Count == 0)
                    {
                        Console.WriteLine("No rooms found in this price range.");
                        break;
                    }

                    foreach (var room in rooms)
                    {
                        Console.WriteLine(
                            $"Room No: {room.RoomNumber}, Type: {room.RoomType}, Price: {room.PricePerNight}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
