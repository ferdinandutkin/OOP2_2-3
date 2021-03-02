using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_2
{

    public static class EnumerableExtensions
    {
        private static readonly Type _enumerableType = typeof(Enumerable);

        public static IEnumerable CastAsType(this IEnumerable source, Type targetType)
        {
            var castMethod = _enumerableType.GetMethod("Cast").MakeGenericMethod(targetType);

            return (IEnumerable)castMethod.Invoke(null, new object[] { source });
        }

        public static IList ToListOfType(this IEnumerable source, Type targetType)
        {
            var enumerable = CastAsType(source, targetType);

            var listMethod = _enumerableType.GetMethod("ToList").MakeGenericMethod(targetType);

            return (IList)listMethod.Invoke(null, new object[] { enumerable });
        }
    }

    public static class Extensions
    {

     

        public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> tuple, out T1 key, out T2 value)
        {
            key = tuple.Key;
            value = tuple.Value;
        }
    }
}
