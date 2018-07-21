using System;
using System.Collections.Generic;

namespace Sorting
{
    /// <summary>
    /// Represents ability of sorting jagged array according to given rules
    /// </summary>
    public static class ArraySorter
    {
        #region Piblic methods
        /// <summary>
        /// Extension method for sorting array's rows according to given rule.
        /// Given rule represent as instance of IComparer
        /// </summary>
        /// <param name="array">Given array to be sorted</param>
        /// <param name="comparator">
        /// Creator instance which can produce unlimited types of sorting
        /// </param>
        public static void BubbleArraySort(this int[][] array, IComparer<int[]> comparator)
        {
            if (array == null || comparator is null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            array.Sort(comparator.Compare);

        }

        /// <summary>
        /// Sorting throw delegate
        /// </summary>
        /// <param name="array">Array to be storted</param>
        /// <param name="comparator">Comparison delegate</param>
        public static void BubbleArraySort(this int[][] array, Comparison<int[]> comparator)
        {
            if (array == null || comparator is null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            array.Sort(Comparer<int[]>.Create(comparator));
        }

        /// <summary>
        /// Internal implementation of sorting throw delegate
        /// </summary>
        /// <param name="array">Array to be sorted</param>
        /// <param name="comparator">Interface</param>
        private static void Sort(this int[][] array, IComparer<int[]> comparator)
        {
            if (array == null || comparator is null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < array.Length; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        SwapRows(ref array[j], ref array[j + 1]);
                        isSorted = false;
                    }
                }
                if (isSorted)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Internal implementation of sorting throw interface
        /// </summary>
        /// <param name="array">Array to be sorted</param>
        /// <param name="comparator">Delegate</param>
        public static void Sort(this int[][] array, Comparison<int[]> comparator)
        {
            if (array == null || comparator is null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < array.Length; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (comparator.Invoke(array[j], array[j + 1]) > 0)
                    {
                        SwapRows(ref array[j], ref array[j + 1]);
                        isSorted = false;
                    }
                }
                if (isSorted)
                {
                    break;
                }
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Custom swapping of two rows
        /// </summary>
        /// <param name="first">First row</param>
        /// <param name="second">Second row</param>
        private static void SwapRows(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        #endregion
    }
}
