public class SwapUsingXor
{
    public void Swap(int a, int b)
    {
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;

        Console.WriteLine($"{a} {b}");

    }
}