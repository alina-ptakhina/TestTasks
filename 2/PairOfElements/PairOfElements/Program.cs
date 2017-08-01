using System;

namespace PairOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 6, 8, -1, -2, 8 };
            int x = 7;
            PairsFinder pairsFinder = new PairsFinder();
            pairsFinder.FindPairs(arr, x);
            Console.WriteLine();
            Console.WriteLine("Количество пар: " + pairsFinder.PairsCount());
            Console.ReadKey();
        }
    }
}
