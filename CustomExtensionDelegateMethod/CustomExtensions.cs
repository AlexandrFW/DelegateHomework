using System.Collections;

namespace DelegateHomework.CustomExtensionDelegateMethod;

public static class CastomExtensions
{
    public static T GetMax<T, TCompare>(this IEnumerable<T> collection, Func<T, TCompare> func) where TCompare : IComparable<TCompare>
    {
        T? maxItem = default;
        TCompare? maxValue = default;
        foreach (var item in collection)
        {
            TCompare temp = func(item);
            if (maxItem == null || temp.CompareTo(maxValue) > 0)
            {
                maxValue = temp;
                maxItem = item;
            }
        }
        return maxItem!;
    }
}