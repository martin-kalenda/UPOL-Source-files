using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    internal interface IIntSet<T> : IEnumerable<T>
    {
        //print elements of set
        public void PrintValues();
        //add element i
        public void Add(T i);
        //check if set contains element i
        public bool Contains(T i);
        // remove element i
        public void Remove(T i);
        // return size of set
        public int Size();
        //return new set containing the union of the original two sets
        public IntSet<T> Union(IntSet<T> other);
        //return new set containing the intersection of the original two sets
        public IntSet<T> Intersection(IntSet<T> other);
        //return new set containing the subtraction of one set from another
        public IntSet<T> Subtract(IntSet<T> other);
        //check if two sets are equal
        public bool AreAqual(IntSet<T> other);
        //check if one set is a subset of the other
        public bool IsSubsetOf(IntSet<T> other);
        //check if set is empty
        public bool IsEmpty();
    }
}
