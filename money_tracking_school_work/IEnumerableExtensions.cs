
namespace money_tracking_school_work
{
    using System.Collections.Generic;

    /*
     * IEnumerableExtensions have extension method for IEnumerable with WithIndex that can be used with foreach to get index
     * example
     foreach (var (item, index) in collection.WithIndex())
        {
            Debug.WriteLine($"{index}: {item}");
        }
     * source https://stackoverflow.com/questions/43021/how-do-you-get-the-index-of-the-current-iteration-of-a-foreach-loop
    */
    public static class IEnumerableExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
           => self.Select((item, index) => (item, index));
    }
}
