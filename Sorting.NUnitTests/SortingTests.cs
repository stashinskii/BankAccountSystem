using System;
using Sorting;
using Sorting.Factory;
using NUnit.Framework;
using System.Collections.Generic;

namespace Sorting.NUnitTests
{
    [TestFixture]
    public class SortingTests
    { 

        [TestCaseSource("SourceAscendingAndMaximim")]
        public void TestSumSotring_Ascending(int[] first, int[] second, int[] third, int[] fourth, int[][] expected)
        {
            int[][] array = new int[4][] { first, second, third, fourth };

            Creator creator = new AscendingCreator();
            array.CustomSort(creator);

            CollectionAssert.AreEqual(expected, array);

        }

        [TestCaseSource("SourceAscendingAndMaximim")]
        public void TestSumSotring_Maximum(int[] first, int[] second, int[] third, int[] fourth, int[][] expected)
        {
            int[][] array = new int[4][] { first, second, third, fourth };

            Creator creator = new MaximumCreator();
            array.CustomSort(creator);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestCaseSource("SourceMinimum")]
        public void TestSumSotring_Minimum(int[] first, int[] second, int[] third, int[][] expected)
        {
            int[][] array = new int[3][] { first, second, third };

            Creator creator = new MinimumCreator();
            array.CustomSort(creator);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestCase(null)]
        public void TestSumSotring_ArgumentNullException(int[][] array) =>
           Assert.Throws(typeof(ArgumentNullException), () => array.CustomSort(new MinimumCreator()));

        [TestCase(null)]
        public void TestSumSotring_CreatorNull_ArgumentNullException(Creator creator) =>
           Assert.Throws(typeof(ArgumentNullException), () => new int[5][].CustomSort(creator));

        [Test]
        public void TestSumSotring_EmptyArray_ArgumentException() =>
           Assert.Throws(typeof(ArgumentException), () => new int[0][].CustomSort(new MinimumCreator()));

        #region Tests sources
        public static IEnumerable<TestCaseData> SourceAscendingAndMaximim()
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
