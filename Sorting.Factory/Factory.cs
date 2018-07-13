using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Factory
{
    /// <summary>
    /// Protocol describing common methods for classes
    /// </summary>
    public abstract class SortingType
    {
        public abstract Tuple<int, int> Operation(int[] current, int[] next);
    }

    /// <summary>
    /// Implementing Operation method for sorting by ascending. 
    /// Also implements helper method for getting Sum
    /// </summary>
    class SortAscending : SortingType
    {
        #region Public methods
        /// <summary>
        /// Implementation of Operation method. Gets sum of two neighbours-values
        /// </summary>
        /// <param name="current">Current row of array</param>
        /// <param name="next">Next row of array</param>
        /// <returns>Tuple of two sum</returns>
        public override Tuple<int, int> Operation(int[] current, int[] next)
        {
            return new Tuple<int, int>(GetSum(current), GetSum(next));
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

    /// <summary>
    /// Implementing Operation method for sorting by maximum element in array. 
    /// Also implements helper method for getting maximum element
    /// </summary>
    class SortByMaximum : SortingType
    {
        #region Public methods
        /// <summary>
        /// Implementation of Operation method. Gets maximum of two neighbours-values
        /// </summary>
        /// <param name="current">Current row of array</param>
        /// <param name="next">Next row of array</param>
        /// <returns>Tuple of two maximum</returns>
        public override Tuple<int, int> Operation(int[] current, int[] next)
        {
            return new Tuple<int, int>(GetMax(current), GetMax(next));
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

    /// <summary>
    /// Implementing Operation mathod for sorting by minimum element in array. 
    /// Also implements helper method for getting minimum element
    /// </summary>
    class SortByMinimum : SortingType
    {
        #region Public methods
        /// <summary>
        /// Implementation of Operation method. Gets minimum of two neighbours-values
        /// </summary>
        /// <param name="current">Current row of array</param>
        /// <param name="next">Next row of array</param>
        /// <returns>Tuple of two minimums</returns>
        public override Tuple<int, int> Operation(int[] current, int[] next)
        {
            return new Tuple<int, int>(GetMin(current), GetMin(next));
        }
        #endregion

        #region Private methods
        #region Private methods
        /// <summary>
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

    /// <summary>
    /// Protocol describing common Factory Method
    /// </summary>
    public abstract class Creator
    {
        /// <summary>
        /// Intrface of Factory Method. Used to produce different instanses, which implements
        /// SortingType class
        /// </summary>
        /// <returns>SortingType instance</returns>
        public abstract SortingType FactoryMethod();
    }

    /// <summary>
    /// Creator for creating SortAscending instance
    /// </summary>
    public class AscendingCreator : Creator
    {
        public override SortingType FactoryMethod() { return new SortAscending(); }
    }

    /// <summary>
    /// Creator for creating SortByMaximum instance
    /// </summary>
    public class MaximumCreator : Creator
    {
        public override SortingType FactoryMethod() { return new SortByMaximum(); }
    }

    /// <summary>
    /// Creator for creating SortByMinimum instance
    /// </summary>
    public class MinimumCreator : Creator
    {
        public override SortingType FactoryMethod() { return new SortByMinimum(); }
    }
    #endregion
}
