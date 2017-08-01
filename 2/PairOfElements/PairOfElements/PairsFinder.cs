using System;
using System.Collections.Generic;
using System.Linq;

namespace PairOfElements
{
    public class PairsFinder
    {
        private int _pairsCount;

        /// <summary>
        /// Вывод всех пар (a, b) таких, что: a + b = X
        /// </summary>
        /// <param name="arr">Входной массив</param>
        /// <param name="x">Число X</param>
        public void FindPairs(int[] arr, int x)
        {
            // Key: уникальный элемент массива. Value: сколько раз элемент встречается в массиве
            Dictionary<int, int> elementCountDictionary = new Dictionary<int, int>();
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int key = x - arr[i];
                if (elementCountDictionary.ContainsKey(key))
                {
                    string pair = string.Format("({0}, {1}) ", key, arr[i]);
                    Console.Write(string.Concat(Enumerable.Repeat(pair, elementCountDictionary[key])));
                    _pairsCount += elementCountDictionary[key];
                }
                if (!elementCountDictionary.ContainsKey(arr[i]))
                    elementCountDictionary.Add(arr[i], 1);
                else
                    elementCountDictionary[arr[i]]++;
            }
        }

        public int PairsCount()
        {
            return _pairsCount;
        }
    }
}
