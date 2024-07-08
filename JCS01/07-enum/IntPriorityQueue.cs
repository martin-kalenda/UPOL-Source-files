using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07
{
    internal class IntPriorityQueue
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
            int i = 0;

            if (!IsEmpty())
            {
                int length = items.Count;

                while (i < length && items[i].Item2 > priority)
                {
                    i++;
                }

                int stoppedAtPriority = items[i].Item2;

                if (stoppedAtPriority == priority)
                {
                    int closestHigher = stoppedAtPriority;
                    int closestLower = stoppedAtPriority;

                    if (i > 0)
                    {
                         closestHigher = items[i - 1].Item2;
                    }
                    if (i < length - 1)
                    {
                        closestLower = items[i + 1].Item2;
                    }
                    throw new ArgumentException($"Duplicate priority, closest used higher: {closestHigher}, lower: {closestLower}");
                } 
            }
            Tuple<int, int> toAdd = Tuple.Create(value, priority);
            items.Insert(i, toAdd);
        }
        //pop next value in queue
        public bool PopNextValue(out int val)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("No items to pop.");
            }

            val = items[0].Item1;

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
