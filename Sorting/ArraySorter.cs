using System;
using Sorting.Factory;


namespace Sorting
{
    /// <summary>
    /// 
    /// </summary>
    public static class ArraySorter
    {
        #region Piblic methods
        /// <summary>
        /// Extension method for sorting array's rows according to given rule.
        /// Given rule represent as instance of Creator
        /// Using Factory pattern
        /// </summary>
        /// <param name="array">Given array to be sorted</param>
        /// <param name="creator">
        /// Creator instance which can produce unlimited types of sorting
        /// </param>
        public static void CustomSort(this int[][] array, Creator creator)
        {
            if (array == null || creator is null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();


            BubbleArraySort(array, creator);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Bubble-Sort helper. Used creator instance to produce SotringType instance. 
        /// Sort rows according to rules, that contains in SortingType instance.
        /// Using Factory pattern
        /// </summary>
        /// <param name="array"></param>
        /// <param name="creator"></param>
        private static void BubbleArraySort(int[][] array, Creator creator)
        {
            SortingType type = creator.FactoryMethod();
            int current, next;
            Tuple<int, int> comparison;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    comparison = type.Operation(array[j], array[j + 1]);
                    current = comparison.Item1; next = comparison.Item2;
                    SwapRows(j, current, next, array);
                }
            }
        }

        /// <summary>
        /// Custom swapping of two rows
        /// </summary>
        /// <param name="position">Current position of sorting</param>
        /// <param name="first">First row</param>
        /// <param name="second">Second row</param>
        /// <param name="array">Given array</param>
        private static void SwapRows(int position, int first, int second, int[][] array)
        {
            if (first > second)
            {
                int[] temp = array[position + 1];
                array[position + 1] = array[position];
                array[position] = temp;
            }
        }

        #endregion
    }
}
