using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.NUnitTests
{
    /// <summary>
    /// Implementation of Compare method. Compare two rows accoring to their Minimum elements
    /// </summary>
    /// <param name="lhs">Current row of array</param>
    /// <param name="rhs">Next row of array</param>
    /// <returns>Comparison of two rows</returns>
    class SortByMin : IComparer<int[]>
    {
        #region Public methods
        /// <summary>
        /// Implementation of IComparer method. Gets minimum of two neighbours-values and compare them
        /// </summary>
        /// <param name="current">Current row of array</param>
        /// <param name="next">Next row of array</param>
        /// <returns>Comparison of two rows</returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs != null)
            {
                return -1;
            }

            if (lhs != null && rhs == null)
            {
                return 1;
            }

            if (lhs == rhs)
            {
                return 0;
            }

            int firstMin = GetMin(lhs);
            int secondMin = GetMin(rhs);

            return firstMin == secondMin ? 0 : firstMin > secondMin ? 1 : -1;
        }
        #endregion

        #region Private methods
        /// Helper method for getting minimum of row of array
        /// </summary>
        /// <param name="array">Given array</param>
        /// <returns>Minimum of row</returns>
        private int GetMin(int[] array)
        {
            int min = array[0];
            foreach (int value in array)
            {
                if (value < min)
                    min = value;
            }
            return min;
        }   
        #endregion
    }
}