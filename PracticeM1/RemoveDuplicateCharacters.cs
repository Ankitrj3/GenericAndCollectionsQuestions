using System.Text;

namespace PracticeM1
{
    public class RemoveDuplicateCharacters
    {
        public void RemoveDuplicate(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in str)
            {
                if (!sb.ToString().Contains(s))
                {
                    sb.Append(s);
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}