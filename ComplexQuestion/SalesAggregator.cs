// Parallel Data Aggregation (PLINQ/Tasks)
// Given List<Sale {Region, Category, Amount, Date}>, compute: 
// Total sales by Region 
// Top category per Region 
// Best sales day overall 
// Use parallel processing safely and produce deterministic output ordering

public class SalesAggregator
{
    public static List<Sale> sales = new List<Sale>();

    public Dictionary<string, double> GetTotalByRegion()
    {
        var result = sales.AsParallel()
            .GroupBy(s => s.Region)
            .Select(g => new { Region = g.Key, Total = g.Sum(s => s.Amount) })
            .OrderBy(x => x.Region)
            .ToDictionary(x => x.Region, x => x.Total);
        return result;
    }

    public Dictionary<string, string> GetTopCategoryPerRegion()
    {
        var result = sales.AsParallel()
            .GroupBy(s => s.Region)
            .Select(regionGroup => new
            {
                Region = regionGroup.Key,
                TopCategory = regionGroup
                    .GroupBy(s => s.Category)
                    .Select(catGroup => new
                    {
                        Category = catGroup.Key,
                        Total = catGroup.Sum(s => s.Amount)
                    })
                    .OrderByDescending(x => x.Total)
                    .First().Category
            })
            .OrderBy(x => x.Region)
            .ToDictionary(x => x.Region, x => x.TopCategory);
        return result;
    }

    public DateTime GetBestSalesDay()
    {
        var result = sales.AsParallel()
            .GroupBy(s => s.Date.Date)
            .Select(g => new
            {
                Date = g.Key,
                Total = g.Sum(s => s.Amount)
            })
            .OrderByDescending(x => x.Total)
            .First().Date;
        return result;
    }

    public void AddSale(string region, string category, double amount, DateTime date)
    {
        Sale s = new Sale()
        {
            Region = region,
            Category = category,
            Amount = amount,
            Date = date
        };
        sales.Add(s);
    }
}
