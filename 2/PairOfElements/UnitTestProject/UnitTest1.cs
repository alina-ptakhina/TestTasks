using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairOfElements;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = { 1, 1, 2, 5, 4, 6, 8, 9, 13, 3, 2, 0, 0 };
            int x = 2;
            PairsFinder pairsFinder = new PairsFinder();
            pairsFinder.FindPairs(arr, x);
            Assert.AreEqual(pairsFinder.PairsCount(), 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] arr = { 1, 1, 1, 1};
            int x = 2;
            PairsFinder pairsFinder = new PairsFinder();
            pairsFinder.FindPairs(arr, x);
            Assert.AreEqual(pairsFinder.PairsCount(), 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] arr = { 1, 3, 5, -10 };
            int x = 10;
            PairsFinder pairsFinder = new PairsFinder();
            pairsFinder.FindPairs(arr, x);
            Assert.AreEqual(pairsFinder.PairsCount(), 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] arr = { 1, 1, 1, 2, 2, 2 };
            int x = 3;
            PairsFinder pairsFinder = new PairsFinder();
            pairsFinder.FindPairs(arr, x);
            Assert.AreEqual(pairsFinder.PairsCount(), 9);
        }
    }
}
