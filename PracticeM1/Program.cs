namespace PracticeM1
{
    public class Program
    {
        public static void Main()
        {
            // ReverseString rs = new ReverseString();
            // rs.Reversestring("ANkit");
            // CheckPalindrome cp = new CheckPalindrome();
            // cp.Check("Mom");
            // CountVowelsInString cs = new CountVowelsInString();
            // cs.CountVowel("aankit");
            // RemoveDuplicateCharacters rdc = new RemoveDuplicateCharacters();
            // rdc.RemoveDuplicate("Programming");
            // ReverseFirstandLastWord rw = new ReverseFirstandLastWord();
            // rw.ReverseStr("Hi Ankit Ranjan");

            // ank.CountDigitString c1 = new ank.CountDigitString();
            // c1.CountNums("Ankit12235467");
            int[] arr = { 12, 34, 21, 56, 78, 90,90,21 };
            // ReverseArray(arr);
            // MaxAndMin(arr);
            // SumOfValue(arr);
            // SecondLargest(arr);
            DeleteDuplicateElement(arr);
            SwapUsingXor s = new SwapUsingXor();
            s.Swap(12,34);

            int [] arr1 = {1,3,4,6,2};
            int n = 6;
            FindMissingNum fd = new FindMissingNum();
            fd.FindMissing(arr1,n);

            int [] arr3 = {1,2,3};
            ProductExceptSelf productExceptSelf = new ProductExceptSelf();
            productExceptSelf.productExceptSelf(arr3);

            int [] arr4 ={1,0,0,23,2,5,0,6};
            MoveZeros mz = new MoveZeros();
            mz.moveZeros(arr4);
        }
        public static void DeleteDuplicateElement(int[] arr)
        {
            int count = 0;
            int n = arr.Length;
            int [] result = new int[n];
            for(int i = 0; i < arr.Length; i++)
            {
                bool isDuplicate = false;
                for(int j = 0; j < count; j++)
                {
                    if(arr[i] == result[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    result[count] = arr[i];
                    count++;
                }
            }
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
        // public static void SecondLargest(int [] arr)
        // {
        //     int max = int.MinValue;
        //     int secondMax = int.MinValue;
        //     for(int i = 0; i < arr.Length; i++)
        //     {
        //         if(arr[i]>max)
        //         {
        //             secondMax = max;
        //             max = arr[i];
        //         }else if(arr[i]>secondMax && secondMax < max)
        //         {
        //             secondMax = arr[i];
        //         }
        //     }
        //     Console.WriteLine($"Second Max Value {secondMax}");
        // }
        // public static void SumOfValue(int [] arr)
        // {
        //     int sum = 0;
        //     for(int i = 0; i < arr.Length; i++)
        //     {
        //         sum += arr[i];
        //     }
        //     Console.WriteLine($"sum of value {sum}");
        // }
        // public static void MaxAndMin(int [] arr)
        // {
        //     int min = int.MaxValue;
        //     int max = int.MinValue;
        //     for(int i = 0; i < arr.Length; i++)
        //     {
        //         if (arr[i] > max)
        //         {
        //             max = arr[i];
        //         }
        //         if (arr[i] < min)
        //         {
        //             min = arr[i];
        //         }
        //     }
        //     Console.WriteLine($"Min Value {min} and Max Value {max}");
        // }
        // public static void ReverseArray(int[] arr)
        // {
        //     for (int i = arr.Length - 1; i >= 0; i--)
        //     {
        //         Console.WriteLine(arr[i]);
        //     }
        // }
    }
}