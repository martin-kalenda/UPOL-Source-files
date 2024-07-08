using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal interface IIntPriorityQueue
    {
        //check if queue is empty
        bool IsEmpty();
        //insert value into queue with given priority
        void InsertWithPriority(int value, int priority);
        //pop next value in queue
        bool PopNextValue(out int val);
        //peek at the next value in queue
        bool PeekNextValue(out int val);
    }
}
