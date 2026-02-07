// Rate Limiter (Sliding Window)
// Implement an API rate limiter: bool AllowRequest(string clientId, DateTime now) 
// Rules: 
// Max 5 requests per 10 seconds per client 
// Sliding window (not fixed blocks) 
// Store only minimal history for performance

public class RateLimiter
{
    public static Dictionary<string, Queue<DateTime>> clientData = new Dictionary<string, Queue<DateTime>>();
    public static int maxReq = 5;
    public static int windowSec = 10;

    public bool AllowRequest(string clientId, DateTime now)
    {
        if(!clientData.ContainsKey(clientId))
        {
            clientData[clientId] = new Queue<DateTime>();
        }

        Queue<DateTime> requests = clientData[clientId];
        DateTime windowStart = now.AddSeconds(-windowSec);

        while(requests.Count > 0 && requests.Peek() <= windowStart)
        {
            requests.Dequeue();
        }

        if(requests.Count < maxReq)
        {
            requests.Enqueue(now);
            return true;
        }
        return false;
    }

    public int GetRemaining(string clientId, DateTime now)
    {
        if(!clientData.ContainsKey(clientId))
        {
            return maxReq;
        }
        Queue<DateTime> requests = clientData[clientId];
        DateTime windowStart = now.AddSeconds(-windowSec);
        int count = 0;
        foreach(var req in requests)
        {
            if(req > windowStart)
            {
                count++;
            }
        }
        return maxReq - count;
    }
}
