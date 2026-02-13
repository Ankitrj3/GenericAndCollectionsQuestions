// static int FirstNonRepeating(int[] arr)
// Input:
// [9, 4, 9, 6, 7, 4]
// Output:
// 6

// Input:
// [1, 1, 1]
// Output:
// -1

using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static int FirstNonRepeating(int[] arr)
    {
        SortedDictionary<int,int> set = new SortedDictionary<int,int>();

        foreach(var i in arr)
        {
            if (set.ContainsKey(i))
            {
                set[i]++;
            }
            else
            {
                set[i] = 1;
            }
        }
        foreach(var i in set)
        {
            if(set[i.Key] == 1)
            {
                return i.Key;
            }
        }
        return -1;
    }
    public static void Main()
    {
        int [] arr = new int[]{9, 4, 9, 6, 7, 4};
        Console.WriteLine(FirstNonRepeating(arr));
    }
}