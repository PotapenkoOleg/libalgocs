using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibAlgoCs.Tries.TernaryTrie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAlgoCs.Common.Interfaces;

namespace LibAlgoCs.Tries.TernaryTrie.Tests
{
    [TestClass()]
    public class TernaryTrieTests
    {
        private ISymbolTable<int> symbolTable;

        private void InitSymbolTable()
        {
            symbolTable.Put("she", 0);
            symbolTable.Put("sells", 1);
            symbolTable.Put("sea", 2);
            symbolTable.Put("shells", 3);
            symbolTable.Put("by", 4);
            symbolTable.Put("the", 5);
            symbolTable.Put("sea", 6);
            symbolTable.Put("shore", 7);
            symbolTable.Put("a", 8);
        }

        [TestInitialize()]
        public void Initialize()
        {
            symbolTable = new TernaryTrie<int>();
            InitSymbolTable();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            symbolTable = null;
        }

        [TestMethod()]
        public void PutTest()
        {
            int expected, actual;

            expected = 8;
            actual = symbolTable.Get("a");
            Assert.Equals(expected, actual);

            expected = 4;
            actual = symbolTable.Get("by");
            Assert.Equals(expected, actual);

            expected = 6;
            actual = symbolTable.Get("sea");
            Assert.Equals(expected, actual);

            expected = 1;
            actual = symbolTable.Get("sells");
            Assert.Equals(expected, actual);

            expected = 0;
            actual = symbolTable.Get("she");
            Assert.Equals(expected, actual);

            expected = 3;
            actual = symbolTable.Get("shells");
            Assert.Equals(expected, actual);

            expected = 7;
            actual = symbolTable.Get("shore");
            Assert.Equals(expected, actual);

            expected = 5;
            actual = symbolTable.Get("the");
            Assert.Equals(expected, actual);
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
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
        public void GetSizeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LongestPrefixOfTest()
        {
            Assert.Fail();
        }



        [TestMethod()]
        public void WildcardMatchTest()
        {
            Assert.Fail();
        }
    }
}