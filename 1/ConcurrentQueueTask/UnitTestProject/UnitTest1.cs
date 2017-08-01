using System;
using System.Threading;
using System.Threading.Tasks;
using ConcurrentQueueTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PopBeforePushTest()
        {
            MyConcurrentQueue<int> myConcurrentQueue = new MyConcurrentQueue<int>();
            var task1 = Task.Factory.StartNew(() => myConcurrentQueue.pop())
                .ContinueWith(T => Assert.AreEqual(T.Result, 1));
            var task2 = Task.Run(() => myConcurrentQueue.push(1));
            Task.WaitAll(new[] {task1, task2});
        }

        [TestMethod]
        public void ParallelTest()
        {
            MyConcurrentQueue<int> myConcurrentQueue = new MyConcurrentQueue<int>();
            int pushCount = 0;
            int popCount = 0;
            var task1 = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, 4, item =>
                {
                    myConcurrentQueue.push(item);
                    Console.WriteLine("push " + item);
                    Interlocked.Increment(ref pushCount);
                });
            });
            var task2 = Task.Run(() =>
            {
                Parallel.For(0, 4, index =>
                {
                    int item = myConcurrentQueue.pop();
                    Console.WriteLine("pop " + item);
                    Interlocked.Increment(ref popCount);
                });

            });
            Task.WaitAll(new[] {task1, task2});
            Assert.AreEqual(pushCount, popCount);
        }
    }
}
