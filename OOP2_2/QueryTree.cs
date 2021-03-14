using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOP2_2
{

    public interface IQueryElement<T>
    {

        
        bool IsMatch(T el);

        bool IsRequired { get; }

    }


    public interface IQueryList : IQueryList<object>
    {
        IEnumerable Apply(IEnumerable collection);
    }


    public interface IQueryList<T> : IQueryElement<T>, IList<IQueryElement<T>>
    /*
     * компоновщик
     * реализующие классы представляют собой одновременно 
     * IQueryElement<T> и IList<IQueryElement<T>> 
     */
    {
        IEnumerable<T> Apply(IEnumerable<T> collection);
    }

    public class QueryTree : QueryTree<object>
    {

        public QueryTree(IEnumerable<IQueryElement<object>> queryElements) : base(queryElements)
        {

        }



        public QueryTree(params IQueryElement<object>[] queryElements) : base(queryElements)
        {

        }

    }

    public class QueryTree<T> : IQueryList<T> 
    {
        readonly List<IQueryElement<T>> queryElements;

        public QueryTree() => queryElements = new();

        public QueryTree(IEnumerable<IQueryElement<T>> queryElements) => this.queryElements = queryElements.ToList();


        public QueryTree(params IQueryElement<T>[] queryElements) => this.queryElements = queryElements.ToList();

        public void Add(IQueryElement<T> queryElement) => queryElements.Add(queryElement);


        public bool IsRequired { get; set; } = true;

        public IEnumerable<T> Apply(IEnumerable<T> collection) => collection.Where(Pred);


        public IEnumerator<IQueryElement<T>> GetEnumerator() => queryElements.GetEnumerator();


        Func<T, bool> Pred
        {
            get
            {

                Func<T, bool> PredFromListElement(IQueryElement<T> el) => obj => el.IsMatch(obj);

                Func<T, bool> Combiner(Func<T, bool> total, IQueryElement<T> current)
                {
                    var pred = PredFromListElement(current);
                    return current.IsRequired ? total.AndAlso(pred) : total.OrElse(pred);
                }

                return obj => queryElements.Skip(1).Aggregate(PredFromListElement(queryElements[0]), Combiner)(obj);

            }

        }

        public int Count => queryElements.Count;

        public bool IsReadOnly => false;

        public IQueryElement<T> this[int index] { get => queryElements[index]; set => queryElements[index] = value; }

        public bool IsMatch(T el) => Pred(el);


        public bool IsMatch(object o) => Pred((T)o);


        IEnumerator IEnumerable.GetEnumerator() => queryElements.GetEnumerator();

        public IEnumerable Apply(IEnumerable collection) => collection.Cast<T>().Where(Pred);

        public int IndexOf(IQueryElement<T> item) => queryElements.IndexOf(item);


        public void Insert(int index, IQueryElement<T> item) => queryElements.Insert(index, item);


        public void RemoveAt(int index) => queryElements.RemoveAt(index);


        public void Clear() => queryElements.Clear();

        public bool Contains(IQueryElement<T> item) => queryElements.Contains(item);


        public void CopyTo(IQueryElement<T>[] array, int arrayIndex) => queryElements.CopyTo(array, arrayIndex);


        public bool Remove(IQueryElement<T> item) => queryElements.Remove(item);

    }
}
