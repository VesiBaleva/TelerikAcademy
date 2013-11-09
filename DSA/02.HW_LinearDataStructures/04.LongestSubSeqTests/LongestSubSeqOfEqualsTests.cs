using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _04.LongestSubsequenceOfEqual;

namespace _04.LongestSubSeqTests
{
    [TestClass]
    public class LongestSubSeqOfEqualsTests
    {
        [TestMethod]
        public void GetLongestSeq_WithOneItem()
        {
            List<int> list=new List<int>(){2};

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);

            List<int> expected=new List<int>() {2};

            CollectionAssert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetLongestSeq_CountOne()
        {
            List<int> list = new List<int>() { 2 };

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void GetLongestSeq_WithDifferentItems()
        {
            List<int> list = new List<int>() { 1, 2, 2, 3, 2, 2, 2, 5, 2, 2 };

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);

            List<int> expected = new List<int>() { 2, 2, 2};

            Assert.AreEqual(3, expected.Count);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSeq_WithSomeEqualsItems()
        {
            List<int> list = new List<int>() { 1, 2, 2, 2, 2, 2, 2 };

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);

            List<int> expected = new List<int>() { 2, 2, 2, 2, 2, 2 };

            Assert.AreEqual(6, expected.Count);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSeq_AllEqualsItems()
        {
            List<int> list = new List<int>() { 2, 2, 2, 2, 2, 2, 2};

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);

            List<int> expected = new List<int>() { 2, 2, 2, 2, 2, 2, 2 };

            Assert.AreEqual(7, expected.Count);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSeq_AllEqualsLongest()
        {
            List<int> list = new List<int>() { 2, 2, 2, 3, 4, 4, 4 };

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);

            List<int> expected = new List<int>() { 2, 2, 2 };

            Assert.AreEqual(3, expected.Count);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLongestSeq_EmtyList()
        {
            List<int> list = new List<int>();

            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(list);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLongestSeq_NullList()
        {
            List<int> actual = LongestSubsequenceOfEquals.GetLongestSeq(null);
        }
    }
}
