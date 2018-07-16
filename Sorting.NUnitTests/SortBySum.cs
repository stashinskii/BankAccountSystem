using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.NUnitTests
{
    class SortBySum : IComparer
    {
        #region Public methods
        /// <summary>
        /// Implementation of Compare method. Compare two rows accoring to their Sum
        /// </summary>
        /// <param name="lhs">Current row of array</param>
        /// <param name="rhs">Next row of array</param>
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

            int firstSum = GetSum(lhs);
            int secondSum = GetSum(rhs);

            return firstSum == secondSum ? 0 : firstSum > secondSum ? 1 : -1;
        }   
        #endregion

        #region Private methods
        /// <summary>
        /// Helper method for getting sum of row of array
        /// </summary>
        /// <param name="array">Given array</param>
        /// <returns>Sum of row</returns>
        private int GetSum(int[] array)
        {
            int result = 0;
            foreach (int value in array)
            {
                result += value;
            }
            return result;
        }
        #endregion
    }
}
