public class CreatorStats
{
    public string? CreatorName{get; set;}
    public double [] WeeklyLikes{get; set;}
    public CreatorStats()
    {
        
    }
    public CreatorStats(string? creatorName, double [] weeklyLikes)
    {
        CreatorName = creatorName;
        WeeklyLikes = weeklyLikes;
    }
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
        Console.WriteLine("User Registered SuccessFully");
    }
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string,int> result = new Dictionary<string, int>();
        foreach(var creator in records)
        {
            int count = 0;
            foreach(var val in creator.WeeklyLikes)
            {
                if(val >= likeThreshold)
                {
                    count++;
                }
                if(count > 0)
                {
                    result.Add(creator.CreatorName,count);
                }
            }
        }
        return result;
    }
    public double CalculateAverageLikes()
    {
        int count = 0;
        double total = 0;

        foreach(var creator in EngagementBoard)
        {
            foreach(var val in creator.WeeklyLikes)
            {
                count ++;
                total += val;
            }
        }
        return total/count;
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}