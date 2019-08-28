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
        [Ignore]
        public void GetAllKeysTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        [Ignore]
        public void GetKeysWithPrefixTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        [Ignore]
        public void WildcardMatchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        [Ignore]
        public void LongestPrefixOfTest()
        {
            Assert.Fail();
        }
    }
}