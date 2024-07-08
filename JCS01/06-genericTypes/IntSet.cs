using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    internal class IntSet<T> : IIntSet<T>
    {
        private List<T> values = new List<T>();

        public List<T> Values
        {
            get { return values; }
            set { values = value; }
        }
        //print elements of set
        public void PrintValues()
        {
            if (Size() != 0)
            {
                foreach (T val in Values)
                {
                    Console.Write(val + " ");
                }
            }
            else
            {
                Console.Write("empty");
            }
            Console.WriteLine();
        }
        //add element i
        public void Add(T i)
        {
            if (i != null && !Contains(i))
            {
                Values.Add(i);
            }
            else
            {
                Console.WriteLine($"Value '{i}' couldn't be added!");
            }
        }
        //check if set contains element i
        public bool Contains(T i)
        {
            if (Values.Contains(i))
            {
                return true;
            }
            return false;
        }
        // remove element i
        public void Remove(T i)
        {
            if (Contains(i))
            {
                Values.Remove(i);
            }
            else
            {
                Console.WriteLine($"Value '{i}' couldn't be removed!");
            }
        }
        // return size of set
        public int Size()
        {
            return Values.Count();
        }
        //return new set containing the union of the original two sets
        public IntSet<T> Union(IntSet<T> other)
        {
            IntSet<T> unified = new IntSet<T>();
            unified.Values = Values.ToList();

            foreach (T val in other.Values)
            {
                if (!unified.Contains(val))
                {
                    unified.Add(val);
                }
            }
            return unified;
        }
        //return new set containing the intersection of the original two sets
        public IntSet<T> Intersection(IntSet<T> other)
        {
            IntSet<T> intersected = new IntSet<T>();

            foreach (T val in Values)
            {
                if (other.Contains(val))
                {
                    intersected.Add(val);
                }
            }
            return intersected;
        }
        //return new set containing the subtraction of one set from another
        public IntSet<T> Subtract(IntSet<T> other)
        {
            IntSet<T> subtracted = new IntSet<T>();

            foreach (T val in Values)
            {
                if (!other.Contains(val))
                {
                    subtracted.Add(val);
                }
            }
            return subtracted;
        }
        //check if two sets are equal
        public bool AreAqual(IntSet<T> other)
        {
            if (Size() != other.Size())
            {
                return false;
            }

            if (IsSubsetOf(other) && other.IsSubsetOf(this))
            {
                return true;
            }
            return false;
        }
        //check if one set is a subset of the other
        public bool IsSubsetOf(IntSet<T> other)
        {
            foreach (T val in Values)
            {
                if (!other.Contains(val))
                {
                    return false;
                }
            }
            return true;
        }
        //check if set is empty
        public bool IsEmpty()
        {
            if (Size() == 0)
            {
                return true;
            }
            return false;
        }
        //IEnumerable interface implementation
        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
