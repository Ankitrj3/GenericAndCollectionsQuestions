// Custom LINQ Extension Methods (yield return)
// Implement your own versions of: 
// WhereEx 
// SelectEx 
// DistinctEx 
// GroupByEx 
// They must work with IEnumerable<T> using yield return

public static class LinqExtensions
{
    public static IEnumerable<T> WhereEx<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach(var item in source)
        {
            if(predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TResult> SelectEx<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
    {
        foreach(var item in source)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<T> DistinctEx<T>(this IEnumerable<T> source)
    {
        HashSet<T> seen = new HashSet<T>();
        foreach(var item in source)
        {
            if(seen.Add(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<IGrouping<TKey, T>> GroupByEx<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        Dictionary<TKey, List<T>> groups = new Dictionary<TKey, List<T>>();
        
        foreach(var item in source)
        {
            TKey key = keySelector(item);
            if(!groups.ContainsKey(key))
            {
                groups[key] = new List<T>();
            }
            groups[key].Add(item);
        }

        foreach(var group in groups)
        {
            yield return new Grouping<TKey, T>(group.Key, group.Value);
        }
    }
}

public class Grouping<TKey, T> : IGrouping<TKey, T>
{
    public TKey Key { get; set; }
    private List<T> items;

    public Grouping(TKey key, List<T> items)
    {
        Key = key;
        this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
