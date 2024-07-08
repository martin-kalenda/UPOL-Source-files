using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal interface IIntSet
    {
        //print elements of set
        public void PrintValues();
        //add element i
        public void Add(int i);
        //check if set contains element i
        public bool Contains(int i);
        // remove element i
        public void Remove(int i);
        // return size of set
        public int Size();
        //return new set containing the union of the original two sets
        public IntSet Union(IntSet other);
        //return new set containing the intersection of the original two sets
        public IntSet Intersection(IntSet other);
        //return new set containing the subtraction of one set from another
        public IntSet Subtract(IntSet other);
        //check if two sets are equal
        public bool AreAqual(IntSet other);
        //check if one set is a subset of the other
        public bool IsSubsetOf(IntSet other);
        //check if set is empty
        public bool IsEmpty();
    }
}
