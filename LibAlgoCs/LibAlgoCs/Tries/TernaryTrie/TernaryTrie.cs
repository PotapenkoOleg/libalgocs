using LibAlgoCs.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace LibAlgoCs.Tries.TernaryTrie
{
    public sealed class TernaryTrie<TValue> : ISymbolTable<TValue>
    {
        #region Private Fields

        private TernaryTrieNode<TValue> Root { get; set; }
        private int Size { get; set; }
        
        #endregion

        #region Node Class

        private sealed class TernaryTrieNode<T>
        {
            private T value = default(T);
            public T Value
            {
                get
                {
                    if (!IsNodeValueSet)
                    {
                        throw new NullReferenceException("Node value is not set.");
                    }
                    else
                    {
                        return value;
                    }
                }
                set
                {
                    this.value = value;
                    IsNodeValueSet = true;
                }
            }
            public bool IsNodeValueSet { get; private set; }
            public void ClearNodeValue()
            {
                IsNodeValueSet = false;
                value = default(T);
            }
            public char Character { get; }
            public TernaryTrieNode<T> Left { get; set; }
            public TernaryTrieNode<T> Middle { get; set; }
            public TernaryTrieNode<T> Right { get; set; }

            public TernaryTrieNode(char character)
            {
                Character = character;
            }
        }
        
        #endregion

        #region Public Methods

        public void Put(string key, TValue value)
        {
            // TODO: balance trie with rotations
            Root = Put(Root, key, value, 0);
        }

        public TValue Get(string key)
        {
            var node = Get(Root, key, 0);
            if (node == null)
            {
                throw new KeyNotFoundException($"Key not found:{key}");
            }
            return node.Value;
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

        #endregion

        #region Private Methods

        private TernaryTrieNode<TValue> Put(TernaryTrieNode<TValue> node, string key, TValue value, int levelCounter)
        {
            var character = key[levelCounter];
            if (node == null)
            {
                node = new TernaryTrieNode<TValue>(character);
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
                if (!node.IsNodeValueSet)
                {
                    Size++;
                }
                node.Value = value;
            }
            return node;
        }

        private TernaryTrieNode<TValue> Get(TernaryTrieNode<TValue> node, string key, int levelCounter)
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

        private TernaryTrieNode<TValue> Delete(TernaryTrieNode<TValue> node, string key, int levelCounter)
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
                node.ClearNodeValue();
                Size--;
                return node;
            }
        }

        private static bool IsNodeEmpty(TernaryTrieNode<TValue> node)
        {
            return !node.IsNodeValueSet && IsNodeHaveNoChildren(node);
        }

        private static bool IsNodeHaveNoChildren(TernaryTrieNode<TValue> node)
        {
            return node.Left == null && node.Middle == null && node.Right == null;
        }

        private static void SetChildToNull(TernaryTrieNode<TValue> parent, TernaryTrieNode<TValue> child)
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
