using LibAlgoCs.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace LibAlgoCs.Tries.Trie
{
    public class Trie<TValue> : ISymbolTable<TValue>
    {
        #region Private Fields

        private const int NUMBER_OF_LETTERS_IN_EXTENDED_ASCII = 256;
        private readonly int numberOfLetters;
        private TrieNode<TValue> root;
        private int size;

        #endregion

        #region Node Class

        private sealed class TrieNode<TItem>
        {
            private TItem value = default(TItem);

            public TItem Value
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
                value = default(TItem);
            }

            public TrieNode<TItem>[] NextLevel { get; }

            public TrieNode(int numberOfLetters) => NextLevel =
                new TrieNode<TItem>[numberOfLetters];

            public void SetNextLevelAt(int index, TrieNode<TItem> next) =>
                NextLevel[index] = next;

            public TrieNode<TItem> GetNextLevelAt(int index) =>
                NextLevel[index];
        }

        #endregion

        #region Constructors

        public Trie() : this(NUMBER_OF_LETTERS_IN_EXTENDED_ASCII) { }

        public Trie(int numberOfLetters)
        {
            this.numberOfLetters = numberOfLetters;
            root = new TrieNode<TValue>(numberOfLetters);
        }

        #endregion

        #region Public Methods

        public void Put(string key, TValue value) =>
            root = Put(root, key, value, 0);

        public TValue Get(string key)
        {
            var node = Get(root, key, 0);
            return (node != null) ? node.Value : throw new KeyNotFoundException($"Key not found:{key}");
        }

        public void Delete(string key) => Delete(root, key, 0);

        public bool Contains(string key)
        {
            try
            {
                Get(key);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Clear()
        {
            root = new TrieNode<TValue>(numberOfLetters);
            size = 0;
        }

        public bool IsEmpty() => IsLevelEmpty(root);

        public int GetSize() => size;

        public IEnumerable<string> GetAllKeys()
        {
            var queue = new List<string>();
            Collect(root, "", queue);
            return queue;
        }

        public IEnumerable<string> GetKeysWithPrefix(string prefix)
        {
            try
            {
                var subTree = Get(root, prefix, 0);
                var queue = new List<string>();
                Collect(subTree, prefix, queue);
                return queue;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public string LongestPrefixOf(string prefix)
        {
            var prefixLength = Search(root, prefix, 0, 0);
            return prefix.Substring(0, prefixLength);
        }

        #endregion

        #region Private Methods

        private TrieNode<TValue> Get(TrieNode<TValue> node, string key, int levelCounter)
        {
            if (node == null)
            {
                return null;
            }
            if (levelCounter == key.Length)
            {
                return node;
            }
            var index = key[levelCounter];
            var nextLevel = node.GetNextLevelAt(index);
            return Get(nextLevel, key, levelCounter + 1);
        }

        private TrieNode<TValue> Put(TrieNode<TValue> node, string key, TValue value, int levelCounter)
        {
            if (node == null)
            {
                node = new TrieNode<TValue>(numberOfLetters);
            }
            if (levelCounter == key.Length)
            {
                if (!node.IsNodeValueSet)
                {
                    size++;
                }
                node.Value = value;
                return node;
            }
            var index = key[levelCounter];
            var nextLevel = node.GetNextLevelAt(index);
            var next = Put(nextLevel, key, value, levelCounter + 1);
            node.SetNextLevelAt(index, next);
            return node;
        }

        private bool Delete(TrieNode<TValue> node, string key, int levelCounter)
        {
            if (node == null)
            {
                return false;
            }
            if (levelCounter == key.Length)
            {
                node.ClearNodeValue();
                size--;
            }
            else
            {
                var index = key[levelCounter];
                var nextLevel = node.GetNextLevelAt(index);
                var isNextLevelEmpty = Delete(nextLevel, key, levelCounter + 1);
                if (isNextLevelEmpty)
                {
                    node.SetNextLevelAt(index, null);
                }
            }
            return IsLevelEmpty(node);
        }

        private bool IsLevelEmpty(TrieNode<TValue> level)
        {
            var hasElement = false;
            foreach (var current in level.NextLevel)
            {
                if (current != null)
                {
                    hasElement = true;
                    break;
                }
            }
            return !hasElement;
        }

        private void Collect(TrieNode<TValue> node, string prefix, IList<string> queue)
        {
            if (node == null)
            {
                return;
            }
            if (node.IsNodeValueSet)
            {
                queue.Add(prefix);
            }
            for (int character = 0; character < numberOfLetters; character++)
            {
                var nextLevel = node.NextLevel;
                Collect(nextLevel[character], prefix + Convert.ToChar(character), queue);
            }
        }

        private int Search(TrieNode<TValue> node, string query, int levelCounter, int prefixLength)
        {
            if (node == null)
            {
                return prefixLength;
            }
            if (node.IsNodeValueSet)
            {
                prefixLength = levelCounter;
            }
            if (levelCounter == query.Length)
            {
                return prefixLength;
            }
            var character = query[levelCounter];
            var nextLevel = node.NextLevel;
            return Search(nextLevel[character], query, levelCounter + 1, prefixLength);
        }

        #endregion
    }
}
