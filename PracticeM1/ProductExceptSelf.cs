public class ProductExceptSelf
{
    public void productExceptSelf(int [] arr)
    {
        int n = arr.Length;
        int [] prefix = new int[n];
        int [] suffix = new int[n];
        int [] result = new int[n];

        prefix[0] = 1;
        for(int i = 1; i < n; i++)
        {
            prefix[i] = prefix[i-1] * arr[i-1];
        }
        suffix[n - 1] = 1;
        for(int i = n - 2; i >= 0; i--)
        {
            suffix[i] = suffix[i+1] * arr[i+1];
        }
        for(int i = 0; i < n; i++)
        {
            result[i] = suffix[i] * prefix[i];
        }

        for(int i = 0; i < n; i++)
        {
            Console.Write(result[i]+" ");
        }
        Console.WriteLine();
    }
}