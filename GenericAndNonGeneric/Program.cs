using System.Collections;
namespace MeetingQuestion
{
    public class Program
    {
        public static void Main()
        {
            ArrayList array = new ArrayList();
            array.Add(1);
            array.Add(234.45);
            array.Add("ankit");
            Console.WriteLine("Non Generic List");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Generic List");
            List<int> list = new List<int>();
            list.Add(12);
            list.Add(23);
            list.Add(567);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
