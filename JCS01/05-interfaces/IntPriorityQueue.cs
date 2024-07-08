using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal class IntPriorityQueue : IIntPriorityQueue
    {
        private List<Tuple<int, int>> items = new List<Tuple<int, int>>();

        //check if queue is empty
        public bool IsEmpty()
        {
            if (items.Count() == 0)
            {
                return true;
            }
            return false;
        }
        //insert value into queue with given priority
        public void InsertWithPriority(int value, int priority)
        {
            items.Add(Tuple.Create(value, priority));
            items.Sort((x, y) => y.Item2.CompareTo(x.Item2));
        }
        //pop next value in queue
        public bool PopNextValue(out int val)
        {
            val = items[0].Item1;

            if (IsEmpty())
            {
                return false;
            }
            items.RemoveAt(0);
            return true;
        }
        //peek at the next value in queue
        public bool PeekNextValue(out int val)
        {
            val = items[0].Item1;

            if (IsEmpty())
            {
                return false;
            }
            return false;
        }
        public override string ToString()
        {
            string converted = "";

            foreach (var item in items)
            {
                converted += (char)item.Item1;
            }
            return converted;
        }
    }
}
