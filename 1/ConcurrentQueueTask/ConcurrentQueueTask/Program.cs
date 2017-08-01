using System;
using System.Threading.Tasks;

namespace ConcurrentQueueTask
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConcurrentQueue<int> myConcurrentQueue = new MyConcurrentQueue<int>();
            Task[] tasks = new Task[4];
            tasks[0] = Task.Factory.StartNew(() => myConcurrentQueue.pop())
                .ContinueWith(T => Console.WriteLine("pop " + T.Result));
            tasks[1] = Task.Run(() =>
            {
                int item = 1;
                myConcurrentQueue.push(item);
                Console.WriteLine("push " + item);
            });
            tasks[2] = Task.Run(() =>
            {
                int item = 2;
                myConcurrentQueue.push(item);
                Console.WriteLine("push " + item);
            });
            tasks[3] = Task.Factory.StartNew(() => myConcurrentQueue.pop())
                .ContinueWith(T => Console.WriteLine("pop " + T.Result));
            Task.WaitAll(tasks);
            Console.ReadKey();
        }
    }
}
