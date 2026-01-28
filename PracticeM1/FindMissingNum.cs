public class FindMissingNum
{
    public void FindMissing(int[] arr, int n)
    {
        int ExpectedAns = (n * (n+1))/2;
        int Solutions = 0;

        for(int i = 0; i < arr.Length; i++)
        {
            Solutions+=arr[i];
        }
        Console.WriteLine(ExpectedAns - Solutions);
    }
}