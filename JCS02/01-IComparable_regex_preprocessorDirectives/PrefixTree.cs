using System;
using System.Collections;
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
     *          CLASS PREFIXTREE         *
     *                                   *
     * * * * * * * * * * * * * * * * * * */
    internal class PrefixTree : IPrefixTree
    {
        private Node _root;

        //prefix tree constructor
        public PrefixTree(string inputText)
        {
            _root = new Node();
            _root.WordEnd = true;

            AddText(inputText);
        }

        //add text to prefix tree
        public void AddText(string inputText)
        {
            string[] words = SplitInput(inputText);

            foreach (string word in words)
            {
                AddWord(word);
            }
        }

        //split input into individual words
        private string[] SplitInput(string inputText)
        {
            return inputText.Split(new char[] { ' ', '\t', '\n', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        }

        //find last node containing a character from given text, return number of traversed characters of text (nodes of prefix tree)
        private (Node, int) FindLast(string text) {
            Node current = _root;
            int traversed = 0;

            foreach (char c in text)
            {
                if (current.Children.ContainsKey(c))
                {
                    current = current.GetChild(c);
                    traversed++;
                }
                else
                {
                    break;
                }
            }
            return (current, traversed);
        }

        //add word to prefix tree
        public void AddWord(string word)
        {
            var (last, traversed) = FindLast(word);

            for (int i = traversed; i < word.Length; i++)
            {
                last.AddChild(new Node(word.Substring(0, i + 1)), word[i]);
                last = last.GetChild(word[i]);
            }
            last.WordEnd = true;
        }

        //check if word is in prefix tree
        public bool Contains(string word)
        {
            var (last, _) = FindLast(word);
            return (last.WordEnd ? true : false) && (last.Text == word);
        }

        //print text of all children of prefix tree node containing given text or "Not in tree" if input is not in tree, Contains() is not used since input doesn't have to be a word
        public void GetChildren(string text)
        {
            List<string> texts = new List<string>();
            var (last, _) = FindLast(text);

            if (last.Text == text)
            {
                foreach (Node child in last.Children.Values)
                {
                    GetTexts(child, texts);
                }
                Console.WriteLine(String.Join(", ", texts));
            } else {
                Console.WriteLine("Not in tree");
            }
        }

        //get text of all children of prefix tree node
        private void GetTexts(Node n, List<string> result)
        {
            result.Add(n.Text);

            foreach (Node child in n.Children.Values)
            {
                GetTexts(child, result);
            }
        }

        //return count of direct children of prefix tree node containing given text, return -1 if input is not in tree, Contains() is not used since input doesn't have to be a word
        public int GetChildrenCount(string text)
        {
            var (last, traversed) = FindLast(text);
            return (traversed == text.Length) ? last.Children.Count : -1;
        }

        //IEnumberable implementation
        public IEnumerator<Node> GetEnumerator()
        {
            return Traverse(_root).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private IEnumerable<Node> Traverse(Node node)
        {
            if (node != null)
            {
                yield return node;

                foreach (Node child in node.Children.Values)
                {
                    foreach (Node n in Traverse(child))
                    {
                        yield return n;
                    }
                }
            }
        }
    }
}