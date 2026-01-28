using System.Security.Cryptography.X509Certificates;

public class CakeOrder
{
    public string? OrderId{get; set;}
    public double CakeCost{get; set;}
    public CakeOrder(){}
    public CakeOrder(string orderId, double cakeCost)
    {
        OrderId = orderId;
        CakeCost = cakeCost;
    }
    private static SortedDictionary<string, double> sortedMap = new SortedDictionary<string, double>();

    public void addOrderDetails(string orderId, double cakeCost)
    {
        if (sortedMap.ContainsKey(orderId))
        {
            Console.WriteLine("Cake Already Present");
        }
        sortedMap[orderId] = cakeCost;
    }
    public Dictionary<string, double> findTheOrderAboveSpecificCost(double cakeCost)
    {
        Dictionary<string, double> res = new Dictionary<string, double>();
        foreach (var item in sortedMap)
        {
            if(item.Value > cakeCost)
            {
                res[item.Key] = item.Value;
            }
        }
        return res;
    }
}
public class Program
{
    public static void Main()
    {
        CakeOrder cake = new CakeOrder();

        Console.WriteLine("Enter Number of Cake you want to Enter");
        string? N = Console.ReadLine();
        int n = int.Parse(N);

        Console.WriteLine("Enter Cake Details OrderID:CakeCost");
        for(int i = 0; i < n; i++)
        {
            string? input = Console.ReadLine();
            string [] stringarr = input.Split(':');
            string orderId = stringarr[0];
            double cakeCost = double.Parse(stringarr[1]);
            cake.addOrderDetails(orderId,cakeCost);
        }
        Console.WriteLine("Enter the Cost to search the cake orders: ");
        string? Cost = Console.ReadLine();
        double cost = double.Parse(Cost);
        Dictionary<string, double> res = cake.findTheOrderAboveSpecificCost(cost);

        foreach(var i in res)
        {
            Console.WriteLine($"Order ID : {i.Key}, Cake Cost : {i.Value}");
        }
    }
}