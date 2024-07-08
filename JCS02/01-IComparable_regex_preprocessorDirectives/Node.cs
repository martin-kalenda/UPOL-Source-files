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
    *            CLASS NODE             *
    *                                   *
    * * * * * * * * * * * * * * * * * * */
    internal class Node
    {
        public string Text { get; }
        public Dictionary<char, Node> Children { get; } = new Dictionary<char, Node>();
        public bool WordEnd { get; set; }

        //node constructor
        public Node() : this("") { }
        public Node(string value) { Text = value; }

        //add child to a node
        public void AddChild(Node child, char key)
        {
            Children[key] = child;
        }
        //get child based on key
        public Node GetChild(char key)
        {
            return Children[key];
        }
    }
}
