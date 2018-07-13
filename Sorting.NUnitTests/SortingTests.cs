using System;
using Sorting;
using Sorting.Factory;
using NUnit.Framework;

namespace Sorting.NUnitTests
{
    [TestFixture]
    public class SortingTests
    {
        [TestCase(new int[] {50, 50, 50}, new int[] { 10, 10, 10 }, new int[] { 60, 60, 60 }, new int[] { 55, 55, 55 })]
        public void TestSumSotring_Ascending(int[] first, int[] second, int[] third, int[] fourth)
        {
            int[][] array = new int[4][];
            array[0] = first;
            array[1] = second;
            array[2] = third;
            array[3] = fourth;

            //TODO больше проверок, как в первом
          
            Creator creator = new AscendingCreator();

            array.CustomSort(creator);

            int[][] result =
            {
                new int[]{10,10,10 },
                new int[]{ 50,50,50},
                new int[]{ 55,55,55},
                new int[]{ 60,60,60}
            };

            CollectionAssert.AreEqual(array, result);

        }

        [TestCase(new int[] { 50, 50, 50 }, new int[] { 10, 10, 10 }, new int[] { 60, 60, 60 }, new int[] { 55, 55, 55 })]
        public void TestSumSotring_Maximum(int[] first, int[] second, int[] third, int[] fourth)
        {
            int[][] array = new int[4][];
            array[0] = first;
            array[1] = second;
            array[2] = third;
            array[3] = fourth;

            //TODO больше проверок, как в первом

            Creator creator = new MinimumCreator();
            array.CustomSort(creator);

            int[][] result =
            {
                new int[]{10,10,10 },
                new int[]{ 50,50,50},
                new int[]{ 55,55,55},
                new int[]{ 60,60,60}
            };

            CollectionAssert.AreEqual(array, result);
            

        }
    }
}
