using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs201
{
   /* * * * * * * * * * * * * * * * * * *
    *                                   *
    *             ÚKOL 1/2              *
    *                                   *
    *       PREFIXTREE INTERFACE        *
    *                                   *
    * * * * * * * * * * * * * * * * * * */
    internal interface IPrefixTree : IEnumerable<Node>
    {
        //check if word is in prefix tree
        public bool Contains(string word);
        //print text of all children of prefix tree node containing given text or "Not in tree" if input is not in tree
        public void GetChildren(string text);
        //return count of direct children of prefix tree node containing given text, return -1 if input is not in tree
        public int GetChildrenCount(string text);
    }
}
