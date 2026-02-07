public class AnagramCheck
{
    public bool CheckAnagram(string a, string b)
    {
        if(a.Length != b.Length)
        {
            return false;
        }
        char [] freq = new char[256];

        foreach(char i in a)
        {
            freq[i]++;
        }
        foreach(char i in b)
        {
            freq[i]--;
        }
        foreach(int i in freq)
        {
            if(i != 0)
            {
                return false;
            }
        }
        return true;
    }
    
}