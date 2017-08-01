using System.Collections.Generic;
using System.Threading;

namespace ConcurrentQueueTask
{
    /// <summary>
    /// Очередь с операциями push(T) и T pop(), поддерживающими обращение с разных потоков. 
    /// </summary>
    /// <typeparam name="T">Элемент очереди</typeparam>
    public class MyConcurrentQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();
        private object _lock = new object();

        public void push(T item)
        {
            lock (_lock)
            {
                _queue.Enqueue(item);
                if (_queue.Count == 1)
                {
                    // В очереди появился новый элемент - отправляем сигнал ожидающим потокам pop
                    Monitor.PulseAll(_lock);
                }
            }
        }

        public T pop()
        {
            lock (_lock)
            {
                while (_queue.Count == 0)
                {
                    // В очереди нет элементов - освобождаем блокировку и ожидаем появления нового элемента.
                    Monitor.Wait(_lock);
                }
                return _queue.Dequeue();
            }
        }
    }
}
