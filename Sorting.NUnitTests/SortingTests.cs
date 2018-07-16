using System;
using Sorting;
using NUnit.Framework;
using System.Collections.Generic;

namespace Sorting.NUnitTests
{
    [TestFixture]
    public class SortingTests
    { 

        [TestCaseSource("SourceSumAndMaximim")]
        public void TestSumSotring_Ascending(int[] first, int[] second, int[] third, int[] fourth, int[][] expected)
        {
            int[][] array = new int[4][] { first, second, third, fourth };

            IComparer comparator = new SortBySum();
            array.BubbleArraySort(comparator);

            CollectionAssert.AreEqual(expected, array);

        }

        [TestCaseSource("SourceSumAndMaximim")]
        public void TestSumSotring_Maximum(int[] first, int[] second, int[] third, int[] fourth, int[][] expected)
        {
            int[][] array = new int[4][] { first, second, third, fourth };

            IComparer comparator = new SortByMax();
            array.BubbleArraySort(comparator);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestCaseSource("SourceMinimum")]
        public void TestSumSotring_Minimum(int[] first, int[] second, int[] third, int[][] expected)
        {
            int[][] array = new int[3][] { first, second, third };

            IComparer comparator = new SortByMin();
            array.BubbleArraySort(comparator);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestCase(null)]
        public void TestSumSotring_ArgumentNullException(int[][] array) =>
           Assert.Throws(typeof(ArgumentNullException), () => array.BubbleArraySort(new SortByMax()));

        [TestCase(null)]
        public void TestSumSotring_CreatorNull_ArgumentNullException(IComparer comparator) =>
           Assert.Throws(typeof(ArgumentNullException), () => new int[5][].BubbleArraySort(comparator));

        [Test]
        public void TestSumSotring_EmptyArray_ArgumentException() =>
           Assert.Throws(typeof(ArgumentException), () => new int[0][].BubbleArraySort(new SortByMax()));


        #region Tests sources
        public static IEnumerable<TestCaseData> SourceSumAndMaximim()
        {
            yield return new TestCaseData(
                new int[] { 50, 50}, new int[] { 10, 10, 10 }, new int[] { 60, 60, 60 }, new int[] { 55, 55 },
                new int[][] { new int[]{ 10, 10, 10 }, new int[]{ 50, 50}, new int[]{ 55, 55 }, new int[]{ 60, 60, 60}});
            yield return new TestCaseData(
               new int[] { 45, 10, 12 }, new int[] { 1, -100, -10 }, new int[] { 10000, -10, 20 }, new int[] { 55, 55, 55 },
               new int[][] { new int[]{ 1, -100, -10 }, new int[]{ 45, 10, 12 }, new int[]{ 55, 55, 55 }, new int[]{ 10000, -10, 20 }});
            yield return new TestCaseData(
               new int[] { -20, 0, 100 }, new int[] { 20, 1000, 12 }, new int[] { 6000, 1000, 2 }, new int[] { 55, 55, 600 },
               new int[][] { new int[] { -20, 0, 100 }, new int[] { 55, 55, 600 }, new int[] { 20, 1000, 12 }, new int[] { 6000, 1000, 2 } });
        }

        public static IEnumerable<TestCaseData> SourceMinimum()
        {
            yield return new TestCaseData(
               new int[] { -1000, 20 }, new int[] { 30, 20, 50 }, new int[] { 1, -50, 10000 },
               new int[][] { new int[] { -1000, 20},  new int[] { 1,-50, 10000}, new int[] { 30, 20, 50}});
            yield return new TestCaseData(
               new int[] { 0, 0, 0 }, new int[] { -20, 1 }, new int[] { 6 },
               new int[][] { new int[] { -20, 1 }, new int[] {0, 0, 0 }, new int[] { 6 } });
        }
        #endregion

    }
}
