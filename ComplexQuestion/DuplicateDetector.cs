// Duplicate Detection with Fuzzy Matching
// Customer duplicates if: 
// Same phone OR 
// Same email OR 
// Name similarity >= 80% (simple edit distance logic) 
// Implement List<DuplicateGroup> FindDuplicates(List<Customer> customers)

public class DuplicateDetector
{
    public List<DuplicateGroup> FindDuplicates(List<Customer> customers)
    {
        List<DuplicateGroup> groups = new List<DuplicateGroup>();
        HashSet<int> processed = new HashSet<int>();

        for(int i = 0; i < customers.Count; i++)
        {
            if(processed.Contains(customers[i].Id))
                continue;

            List<Customer> duplicates = new List<Customer>();
            duplicates.Add(customers[i]);
            processed.Add(customers[i].Id);
            string reason = "";

            for(int j = i + 1; j < customers.Count; j++)
            {
                if(processed.Contains(customers[j].Id))
                    continue;

                string matchReason = IsDuplicate(customers[i], customers[j]);
                if(matchReason != "")
                {
                    duplicates.Add(customers[j]);
                    processed.Add(customers[j].Id);
                    if(reason == "")
                        reason = matchReason;
                }
            }

            if(duplicates.Count > 1)
            {
                DuplicateGroup group = new DuplicateGroup();
                group.Customers = duplicates;
                group.Reason = reason;
                groups.Add(group);
            }
        }

        return groups;
    }

    private string IsDuplicate(Customer c1, Customer c2)
    {
        if(!string.IsNullOrEmpty(c1.Phone) && !string.IsNullOrEmpty(c2.Phone) && c1.Phone == c2.Phone)
        {
            return "Same Phone";
        }

        if(!string.IsNullOrEmpty(c1.Email) && !string.IsNullOrEmpty(c2.Email) && c1.Email.ToLower() == c2.Email.ToLower())
        {
            return "Same Email";
        }

        double similarity = CalculateNameSimilarity(c1.Name, c2.Name);
        if(similarity >= 80)
        {
            return $"Name Similarity {similarity:F1}%";
        }

        return "";
    }

    private double CalculateNameSimilarity(string name1, string name2)
    {
        if(string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            return 0;

        name1 = name1.ToLower().Trim();
        name2 = name2.ToLower().Trim();

        int distance = LevenshteinDistance(name1, name2);
        int maxLen = Math.Max(name1.Length, name2.Length);
        
        double similarity = (1.0 - (double)distance / maxLen) * 100;
        return similarity;
    }

    private int LevenshteinDistance(string s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

        for(int i = 0; i <= s1.Length; i++)
            dp[i, 0] = i;

        for(int j = 0; j <= s2.Length; j++)
            dp[0, j] = j;

        for(int i = 1; i <= s1.Length; i++)
        {
            for(int j = 1; j <= s2.Length; j++)
            {
                int cost = s1[i - 1] == s2[j - 1] ? 0 : 1;
                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
            }
        }

        return dp[s1.Length, s2.Length];
    }
}
