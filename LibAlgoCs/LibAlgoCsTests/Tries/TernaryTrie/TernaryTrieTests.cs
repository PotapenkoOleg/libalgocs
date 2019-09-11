using LibAlgoCs.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibAlgoCs.Tries.TernaryTrie.Tests
{
    [TestClass()]
    public class TernaryTrieTests
    {
        private ISymbolTable<int> _symbolTable;

        private void InitSymbolTable()
        {
            _symbolTable.Put("she", 0);
            _symbolTable.Put("sells", 1);
            _symbolTable.Put("sea", 2);
            _symbolTable.Put("shells", 3);
            _symbolTable.Put("by", 4);
            _symbolTable.Put("the", 5);
            _symbolTable.Put("sea", 6);
            _symbolTable.Put("shore", 7);
            _symbolTable.Put("a", 8);
        }

        [TestInitialize()]
        public void Initialize()
        {
            _symbolTable = new TernaryTrie<int>();
            InitSymbolTable();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _symbolTable = null;
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void PutTest()
        {
            var expected = 8;
            var actual = _symbolTable.Get("a");
            Assert.AreEqual(expected, actual);

            expected = 4;
            actual = _symbolTable.Get("by");
            Assert.AreEqual(expected, actual);

            expected = 6;
            actual = _symbolTable.Get("sea");
            Assert.AreEqual(expected, actual);

            expected = 1;
            actual = _symbolTable.Get("sells");
            Assert.AreEqual(expected, actual);

            expected = 0;
            actual = _symbolTable.Get("she");
            Assert.AreEqual(expected, actual);

            expected = 3;
            actual = _symbolTable.Get("shells");
            Assert.AreEqual(expected, actual);

            expected = 7;
            actual = _symbolTable.Get("shore");
            Assert.AreEqual(expected, actual);

            expected = 5;
            actual = _symbolTable.Get("the");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void GetTest()
        {
            var expected = 8;
            var actual = _symbolTable.Get("a");
            Assert.AreEqual(expected, actual);

            expected = 4;
            actual = _symbolTable.Get("by");
            Assert.AreEqual(expected, actual);

            expected = 6;
            actual = _symbolTable.Get("sea");
            Assert.AreEqual(expected, actual);

            expected = 1;
            actual = _symbolTable.Get("sells");
            Assert.AreEqual(expected, actual);

            expected = 0;
            actual = _symbolTable.Get("she");
            Assert.AreEqual(expected, actual);

            expected = 3;
            actual = _symbolTable.Get("shells");
            Assert.AreEqual(expected, actual);

            expected = 7;
            actual = _symbolTable.Get("shore");
            Assert.AreEqual(expected, actual);

            expected = 5;
            actual = _symbolTable.Get("the");
            Assert.AreEqual(expected, actual);

            // invalid entry            
            Assert.ThrowsException<KeyNotFoundException>(() => _symbolTable.Get("invalid"));
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void DeleteTest()
        {
            // clear all entries
            _symbolTable.Delete("she");
            _symbolTable.Delete("sells");
            _symbolTable.Delete("sea");
            _symbolTable.Delete("shells");
            _symbolTable.Delete("by");
            _symbolTable.Delete("the");
            _symbolTable.Delete("sea");
            _symbolTable.Delete("shore");
            _symbolTable.Delete("a");

            var expected = 0;
            object actual = _symbolTable.GetSize();
            Assert.AreEqual(expected, actual);

            InitSymbolTable();

            _symbolTable.Delete("by");
            Assert.ThrowsException<KeyNotFoundException>(() => _symbolTable.Get("by"));

            _symbolTable.Delete("shore");
            Assert.ThrowsException<KeyNotFoundException>(() => _symbolTable.Get("shore"));

            expected = 3;
            actual = _symbolTable.Get("shells");
            Assert.AreEqual(expected, actual);

            expected = 6;
            actual = _symbolTable.Get("sea");
            Assert.AreEqual(expected, actual);

            _symbolTable.Delete("sea");
            expected = 1;
            actual = _symbolTable.Get("sells");
            Assert.AreEqual(expected, actual);

            // invalid entry
            _symbolTable.Delete("by");
            Assert.ThrowsException<KeyNotFoundException>(() => _symbolTable.Get("by"));

            // delete root
            _symbolTable.Clear();
            _symbolTable.Put("a", 0);
            _symbolTable.Delete("a");
            Assert.ThrowsException<KeyNotFoundException>(() => _symbolTable.Get("a"));
            expected = 0;
            actual = _symbolTable.GetSize();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void ClearTest()
        {
            var actual = _symbolTable.IsEmpty();
            Assert.IsFalse(actual);

            _symbolTable.Clear();
            actual = _symbolTable.IsEmpty();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void IsEmptyTest()
        {
            var actual = _symbolTable.IsEmpty();
            Assert.IsFalse(actual);

            _symbolTable.Clear();
            actual = _symbolTable.IsEmpty();
            Assert.IsTrue(actual);

            _symbolTable.Put("placeholder", 42);
            actual = _symbolTable.IsEmpty();
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void GetSizeTest()
        {
            var expected = 8;
            var actual = _symbolTable.GetSize();
            Assert.AreEqual(expected, actual);

            _symbolTable.Delete("by");
            expected = 7;
            actual = _symbolTable.GetSize();
            Assert.AreEqual(expected, actual);

            _symbolTable.Clear();
            expected = 0;
            actual = _symbolTable.GetSize();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void GetAllKeysTest()
        {
            var dictionary = new Dictionary<string, int>
            {
                { "she", 0 },
                { "sells", 0 },
                { "shells", 0 },
                { "by", 0 },
                { "the", 0 },
                { "sea", 0 },
                { "shore", 0 },
                { "a", 0 }
            };

            var allKeys = _symbolTable.GetAllKeys();

            int expected = 8;
            int actual = CheckKeys(allKeys, dictionary);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void GetKeysWithPrefixTest()
        {
            var dictionary = new Dictionary<string, int>
            {
                {"she", 0 },
                { "sells", 0},
                { "shells", 0},
                { "sea", 0},
                { "shore", 0}
            };

            var prefix = "s";

            var allKeys = _symbolTable.GetKeysWithPrefix(prefix);

            var expected = 5;
            var actual = CheckKeys(allKeys, dictionary);
            Assert.AreEqual(expected, actual);

            dictionary.Clear();

            dictionary.Add("she", 0);
            dictionary.Add("shells", 0);
            dictionary.Add("shore", 0);

            prefix = "sh";

            allKeys = _symbolTable.GetKeysWithPrefix(prefix);

            expected = 3;
            actual = CheckKeys(allKeys, dictionary);
            Assert.AreEqual(expected, actual);

            prefix = "Invalid";

            allKeys = _symbolTable.GetKeysWithPrefix(prefix);
            Assert.IsNull(allKeys);
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void LongestPrefixOfTest()
        {
            var expected = "shells";
            var actual = _symbolTable.LongestPrefixOf("shellsort");
            Assert.AreEqual(expected, actual);

            expected = "a";
            actual = _symbolTable.LongestPrefixOf("a");
            Assert.AreEqual(expected, actual);

            actual = _symbolTable.LongestPrefixOf("Invalid");
            Assert.IsNull(actual);

            _symbolTable.Clear();

            _symbolTable.Put("128", 0);
            _symbolTable.Put("128.112.055", 0);
            _symbolTable.Put("128.112.055.015", 0);
            _symbolTable.Put("128.112.136", 0);
            _symbolTable.Put("128.112.155.011", 0);
            _symbolTable.Put("128.112.155.013", 0);
            _symbolTable.Put("128.112", 0);
            _symbolTable.Put("128.222", 0);
            _symbolTable.Put("128.222.136", 0);

            expected = "128.112.136";
            actual = _symbolTable.LongestPrefixOf("128.112.136.011");
            Assert.AreEqual(expected, actual);

            expected = "128.112";
            actual = _symbolTable.LongestPrefixOf("128.112.100.016");
            Assert.AreEqual(expected, actual);

            expected = "128";
            actual = _symbolTable.LongestPrefixOf("128.166.123.045");
            Assert.AreEqual(expected, actual);

            _symbolTable.Clear();
            _symbolTable.Put("a", 0);
            expected = "a";
            actual = _symbolTable.LongestPrefixOf("a");
            Assert.AreEqual(expected, actual);
        }

        private int CheckKeys(IEnumerable<string> allKeys, Dictionary<string, int> dictionary)
        {
            var numberOfItems = 0;
            foreach (var key in allKeys)
            {
                numberOfItems++;
                var value = dictionary[key];
            }
            return numberOfItems;
        }
    }
}