using System;

public class Program
{
    public static void RightRotateEasy(int[] arr, int k)
    {

        int n = arr.Length;
        k = k%n;
        if(n == 0)
        {
            return;
        }
        int [] res = new int[n];
        for(int i = 0; i < n; i++)
        {
            res[(i + k)%n] = arr[i];
        }
        for(int i = 0; i < n; i++)
        {
            arr[i] = res[i];
        }
    }

    public static void Main()
    {
        int [] arr = {12,34,56,78,5,8,97};
        int k = 3;

        RightRotateEasy(arr,k);
        foreach(var i in arr)
        {
            Console.Write(i+" ");
        }
    }
}
