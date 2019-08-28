using LibAlgoCs.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibAlgoCs.Tries.TernaryTrie.Tests
{
    [TestClass()]
    public class TernaryTrieTests
    {
        private ISymbolTable<object> _symbolTable;

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
            _symbolTable = new TernaryTrie<object>();
            InitSymbolTable();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _symbolTable = null;
        }

        [TestMethod()]
        public void PutTest()
        {
            var expected = 8;
            var actual = _symbolTable.Get("a");
            Assert.Equals(expected, actual);

            expected = 4;
            actual = _symbolTable.Get("by");
            Assert.Equals(expected, actual);

            expected = 6;
            actual = _symbolTable.Get("sea");
            Assert.Equals(expected, actual);

            expected = 1;
            actual = _symbolTable.Get("sells");
            Assert.Equals(expected, actual);

            expected = 0;
            actual = _symbolTable.Get("she");
            Assert.Equals(expected, actual);

            expected = 3;
            actual = _symbolTable.Get("shells");
            Assert.Equals(expected, actual);

            expected = 7;
            actual = _symbolTable.Get("shore");
            Assert.Equals(expected, actual);

            expected = 5;
            actual = _symbolTable.Get("the");
            Assert.Equals(expected, actual);
        }

        [TestMethod()]
        public void GetTest()
        {
            var expected = 8;
            var actual = _symbolTable.Get("a");
            Assert.Equals(expected, actual);

            expected = 4;
            actual = _symbolTable.Get("by");
            Assert.Equals(expected, actual);

            expected = 6;
            actual = _symbolTable.Get("sea");
            Assert.Equals(expected, actual);

            expected = 1;
            actual = _symbolTable.Get("sells");
            Assert.Equals(expected, actual);

            expected = 0;
            actual = _symbolTable.Get("she");
            Assert.Equals(expected, actual);

            expected = 3;
            actual = _symbolTable.Get("shells");
            Assert.Equals(expected, actual);

            expected = 7;
            actual = _symbolTable.Get("shore");
            Assert.Equals(expected, actual);

            expected = 5;
            actual = _symbolTable.Get("the");
            Assert.Equals(expected, actual);

            // invalid entry
            actual = _symbolTable.Get("invalid");
            Assert.IsNull(actual);
        }

        [TestMethod()]
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
            Assert.Equals(expected, actual);

            InitSymbolTable();

            _symbolTable.Delete("by");
            actual = _symbolTable.Get("by");
            Assert.IsNull(actual);

            _symbolTable.Delete("shore");
            actual = _symbolTable.Get("shore");
            Assert.IsNull(actual);

            expected = 3;
            actual = _symbolTable.Get("shells");
            Assert.Equals(expected, actual);

            expected = 6;
            actual = _symbolTable.Get("sea");
            Assert.Equals(expected, actual);

            _symbolTable.Delete("sea");
            expected = 1;
            actual = _symbolTable.Get("sells");
            Assert.Equals(expected, actual);

            // invalid entry
            _symbolTable.Delete("by");
            actual = _symbolTable.Get("by");
            Assert.IsNull(actual);

            // delete root
            _symbolTable.Clear();
            _symbolTable.Put("a", 0);
            _symbolTable.Delete("a");
            actual = _symbolTable.Get("a");
            Assert.IsNull(actual);
            expected = 0;
            actual = _symbolTable.GetSize();
            Assert.Equals(expected, actual);
        }

        [TestMethod()]
        public void ClearTest()
        {
            var actual = _symbolTable.IsEmpty();
            Assert.IsFalse(actual);

            _symbolTable.Clear();
            actual = _symbolTable.IsEmpty();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
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
        public void GetSizeTest()
        {
            var expected = 8;
            var actual = _symbolTable.GetSize();
            Assert.Equals(expected, actual);

            _symbolTable.Delete("by");
            expected = 7;
            actual = _symbolTable.GetSize();
            Assert.Equals(expected, actual);

            _symbolTable.Clear();
            expected = 0;
            actual = _symbolTable.GetSize();
            Assert.Equals(expected, actual);
        }

        [TestMethod()]
        public void GetAllKeysTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetKeysWithPrefixTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WildcardMatchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LongestPrefixOfTest()
        {
            Assert.Fail();
        }
    }
}