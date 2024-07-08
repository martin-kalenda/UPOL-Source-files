using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    internal class IntSet
    {
        private List<int> values = new List<int>();

        public List<int> Values
        {
            get { return values; }
            set { values = value; }
        }
        //print elements of set
        public void PrintValues()
        {
            if (Size() != 0)
            {
                foreach (int val in Values)
                {
                    Console.Write(val + " ");
                }
            } else
            {
                Console.Write("empty");
            }
            Console.WriteLine();
        }
        //add element i
        public void Add(int i)
        {
            if (!Contains(i)) {
                Values.Add(i);
            } else
            {
                Console.WriteLine($"Value '{i}' couldn't be added!");
            }
        }
        //check if set contains element i
        public bool Contains(int i)
        {
            if (Values.Contains(i))
            {
                return true;
            }
            return false;
        }
        // remove element i
        public void Remove(int i)
        {
            if (Contains(i)) {
                Values.Remove(i);
            } else
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
        public IntSet Union(IntSet other)
        {
            IntSet unified = new IntSet();
            unified.Values = Values.ToList();

            foreach (int val in other.Values)
            {
                if (!unified.Contains(val)) {
                    unified.Add(val);
                }
            }
            return unified;
        }
        //return new set containing the intersection of the original two sets
        public IntSet Intersection(IntSet other)
        {
            IntSet intersected = new IntSet();

            foreach (int val in Values)
            {
                if (other.Contains(val))
                {
                    intersected.Add(val);
                }
            }
            return intersected;
        }
        //return new set containing the subtraction of one set from another
        public IntSet Subtract(IntSet other)
        {
            IntSet subtracted = new IntSet();

            foreach (int val in Values)
            {
                if (!other.Contains(val))
                {
                    subtracted.Add(val);
                }
            }
            return subtracted;
        }
        //check if two sets are equal
        public bool AreAqual(IntSet other)
        {
            if (Size() != other.Size())
            {
                return false;
            }
            foreach (int val in Values)
            {
                if (!other.Contains(val))
                {
                    return false;
                }
            }
            return true;
        }
        //check if one set is a subset of the other
        public bool IsSubsetOf(IntSet other)
        {
            foreach (int val in Values)
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
    }
}
