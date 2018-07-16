using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.NUnitTests
{
    /// <summary>
    /// Implementation of Compare method. Compare two rows accoring to their Maximum elements
    /// </summary>
    /// <param name="lhs">Current row of array</param>
    /// <param name="rhs">Next row of array</param>
    /// <returns>Comparison of two rows</returns>
    class SortByMax : IComparer
    {
        #region Public methods
        /// <summary>
        /// Implementation of IComparer method. Gets maximum of two neighbours-values and compare them
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

            int firstMax = GetMax(lhs);
            int secondMax = GetMax(rhs);

            return firstMax == secondMax ? 0 : firstMax > secondMax ? 1 : -1;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Helper method for getting maximum of row of array
        /// </summary>
        /// <param name="array">Given array</param>
        /// <returns>Maximum of row</returns>
        private int GetMax(int[] array)
        {
            int max = array[0];
            foreach (int value in array)
            {
                if (value > max)
                    max = value;
            }
            return max;

        }
        #endregion
    }
}
