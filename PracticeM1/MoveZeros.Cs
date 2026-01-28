public class MoveZeros
{
    public void moveZeros(int [] arr)
    {
        int index = 0;
        int n = arr.Length;
        for(int i = 0; i < n; i++)
        {
            if (arr[i] != 0)
            {
                arr[index] = arr[i];
                index++;
            }
        }
        while(index < n)
        {
            arr[index] = 0;
            index ++;
        }
        for(int i = 0; i < n; i++)
        {
            Console.Write(arr[i]+" ");
        }Console.WriteLine();
    }

}