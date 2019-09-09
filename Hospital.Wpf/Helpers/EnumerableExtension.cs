using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.Wpf.Helpers
{
    public static class EnumerableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source) where T : class
        {
            var result = new ObservableCollection<T>();
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    result.Add(enumerator.Current);
                }
            }
            return result;
        }

    }
}
