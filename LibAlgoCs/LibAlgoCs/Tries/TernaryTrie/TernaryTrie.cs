using LibAlgoCs.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace LibAlgoCs.Tries.TernaryTrie
{
    public class TernaryTrie<TValue> : ISymbolTable<TValue>
        where TValue : class
    {
        private Node<TValue> Root { get; set; }
        private int Size { get; set; }

        #region Node Class
        private sealed class Node<T>
        {
            public char Character { get; }
            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Middle { get; set; }
            public Node<T> Right { get; set; }

            public Node(char character)
            {
                Character = character;
            }
        }
        #endregion
        public void Put(string key, TValue value)
        {
            // TODO: balance trie with rotations
            Root = Put(Root, key, value, 0);
        }

        public TValue Get(string key)
        {
            var node = Get(Root, key, 0);
            return node?.Value;
        }

        public void Delete(string key)
        {
            var child = Delete(Root, key, 0);
            SetChildToNull(Root, child);
            if (IsNodeEmpty(Root))
            {
                Root = null;
            }
        }

        public bool Contains(string key)
        {
            return Get(key) != null;
        }

        public void Clear()
        {
            Root = null;
            Size = 0;
        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public int GetSize()
        {
            return Size;
        }

        public IEnumerable<string> GetAllKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetKeysWithPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public string[] WildcardMatch(string key)
        {
            throw new NotImplementedException();
        }

        public string LongestPrefixOf(string prefix)
        {
            throw new NotImplementedException();
        }

        #region Private Methods

        private Node<TValue> Put(Node<TValue> node, string key, TValue value, int levelCounter)
        {
            var character = key[levelCounter];
            if (node == null)
            {
                node = new Node<TValue>(character);
            }
            if (character < node.Character)
            {
                node.Left = Put(node.Left, key, value, levelCounter);
            }
            else if (character > node.Character)
            {
                node.Right = Put(node.Right, key, value, levelCounter);
            }
            else if (levelCounter < key.Length - 1)
            {
                node.Middle = Put(node.Middle, key, value, levelCounter + 1);
            }
            else
            {
                if (node.Value == null)
                {
                    Size++;
                }
                node.Value = value;
            }
            return node;
        }

        private Node<TValue> Get(Node<TValue> node, string key, int levelCounter)
        {
            if (node == null)
            {
                return null;
            }
            var character = key[levelCounter];
            if (character < node.Character)
            {
                return Get(node.Left, key, levelCounter);
            }
            else if (character > node.Character)
            {
                return Get(node.Right, key, levelCounter);
            }
            else if (levelCounter < key.Length - 1)
            {
                return Get(node.Middle, key, levelCounter + 1);
            }
            else return node;
        }

        private Node<TValue> Delete(Node<TValue> node, string key, int levelCounter)
        {
            if (node == null)
            {
                return null;
            }
            var character = key[levelCounter];
            if (character < node.Character)
            {
                var childNode = Delete(node.Left, key, levelCounter);
                if (childNode != null && IsNodeEmpty(childNode))
                {
                    SetChildToNull(node, childNode);
                }
                return node;
            }
            else if (character > node.Character)
            {
                var childNode = Delete(node.Right, key, levelCounter);
                if (childNode != null && IsNodeEmpty(childNode))
                {
                    SetChildToNull(node, childNode);
                }
                return node;
            }
            else if (levelCounter < key.Length - 1)
            {
                var childNode = Delete(node.Middle, key, levelCounter + 1);
                if (childNode != null && IsNodeEmpty(childNode))
                {
                    SetChildToNull(node, childNode);
                }
                return node;
            }
            else
            {
                node.Value = null;
                Size--;
                return node;
            }
        }

        private static bool IsNodeEmpty(Node<TValue> node)
        {
            return node.Value == null && IsNodeHaveNoChildren(node);
        }

        private static bool IsNodeHaveNoChildren(Node<TValue> node)
        {
            return node.Left == null && node.Middle == null && node.Right == null;
        }

        private static void SetChildToNull(Node<TValue> parent, Node<TValue> child)
        {
            if (parent == null)
            {
                return;
            }
            if (parent.Left == child)
            {
                parent.Left = null;
            }
            if (parent.Middle == child)
            {
                parent.Middle = null;
            }
            if (parent.Right == child)
            {
                parent.Right = null;
            }
        }

        #endregion
    }
}
