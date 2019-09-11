using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibAlgoCs.Tries.Trie.Tests
{
    [TestClass()]
    public class TrieTests
    {
        [TestInitialize()]
        public void Initialize()
        {
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod()]
        [TestCategory("UnitTest")]
        public void ClearTest()
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
        [Ignore]
        public void GetAllKeysTest()
        {
            //var map = new Dictionary<string, int>
            //{
            //    { "she", 0 },
            //    { "sells", 0 },
            //    { "shells", 0 },
            //    { "by", 0 },
            //    { "the", 0 },
            //    { "sea", 0 },
            //    { "shore", 0 },
            //    { "a", 0 }
            //};

            //IEnumerable<string> allKeys = _symbolTable.GetAllKeys();

            //int expected = 8;
            //int actual = CheckKeys(allKeys, map);
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [Ignore]
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
        [Ignore]
        public void LongestPrefixOfTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [Ignore]
        public void WildcardMatchTest()
        {
            Assert.Fail();
        }

        private int CheckKeys(IEnumerable<string> allKeys, Dictionary<string, int> map)
        {
            var numberOfItems = 0;
            foreach (var key in allKeys)
            {
                numberOfItems++;
                var value = map[key];
            }
            return numberOfItems;
        }
    }
}