using System.Security.Cryptography.X509Certificates;

public class GenericDataFilter
{
    public List<T> FilterData<T>(List<T> Products, Predicate<T> condition)
    {
        List<T> res = new List<T>();
        foreach(var item in Products)
        {
            if (condition(item))
            {
                res.Add(item);
            }
        }
        return res;
    }
}
public class Excute
{
    public void ExcuteProgram()
    {
        List<int> data = new List<int>();
        data.Add(1);
        data.Add(2);
        data.Add(4);
        data.Add(5);
        var filter = new GenericDataFilter();
        List<int> res = filter.FilterData(data, num => num%2==0);
        List<string> da = new List<string>();
        da.Add("kamaljeet");
        da.Add("Shashi");
        da.Add("Rob");
        da.Add("Ankit");
        List<string> res1 = filter.FilterData(da, str => str.Length > 6);

        foreach(var i in res)
        {
            Console.WriteLine(i);
        }
        foreach(var j in res1)
        {
            Console.WriteLine(j);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var ex = new Excute();
        ex.ExcuteProgram();
    }
}