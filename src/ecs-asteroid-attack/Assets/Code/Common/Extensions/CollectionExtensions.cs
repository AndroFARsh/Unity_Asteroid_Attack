using System.Collections;
using System.Collections.Generic;

namespace Code.Common.Extensions
{
  public static class CollectionExtensions
  {
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
      foreach (T item in items)
      {
        collection.Add(item);
      }
    }

    public static void AddRange(this IList list, IEnumerable items)
    {
      foreach (object item in items)
      {
        list.Add(item);
      }
    }
  }
}