using NUnit.Framework;
using System.Linq;

namespace tests
{
    public class Tests
    {
        private int[,] testMatrix;
        private matrix_sort.MatrixSorter sorter;

        private int[][] toJagged(int[,] array2d)
        {
            int[][] result = new int[array2d.GetLength(0)][];
            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                result[i] = new int[array2d.GetLength(1)];
                for (int j = 0; j < array2d.GetLength(1); j++)
                    result[i][j] = array2d[i, j];
            }
            return result;
        }

        private int[,] to2d(int[][] jagged)
        {
            int[,] result = new int[jagged.Length, jagged[0].Length];
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j] = jagged[i][j];
            return result;
        }

        [SetUp]
        public void Setup()
        {
            testMatrix = new int[,] {
                { -1, 2, -5, 6, 7, 0 },   // sum = 9,  min = -5, max = 7
                { 0, 4, 6, 8, -1, -3 },   // sum = 14, min = -3, max = 8
                { 1, 2, 3, -4, -5, -6 },  // sum = -9, min = -6, max = 3
                { 12, -5, -8, -9, 3, 5 }, // sum = -2, min = -9, max = 12
            };
            sorter = new matrix_sort.MatrixSorter();
        }

        [Test]
        public void SumSortTest()
        {
            sorter.IsLessStrategy = matrix_sort.SortOrders.SumIsLess;

            int[][] jagged;
            sorter.SortMatrix(testMatrix, ascending: true);

            jagged = toJagged(testMatrix);
            Assert.AreEqual(testMatrix, to2d(jagged.OrderBy(row => row.Sum()).ToArray()));

            sorter.SortMatrix(testMatrix, ascending: false);

            jagged = toJagged(testMatrix);
            Assert.AreEqual(testMatrix, to2d(jagged.OrderBy(row => -row.Sum()).ToArray()));
        }

        [Test]
        public void MaxSortTest()
        {
            sorter.IsLessStrategy = matrix_sort.SortOrders.MaxIsLess;

            int[][] jagged;
            sorter.SortMatrix(testMatrix, ascending: true);

            jagged = toJagged(testMatrix);
            Assert.AreEqual(testMatrix, to2d(jagged.OrderBy(row => row.Max()).ToArray()));

            sorter.SortMatrix(testMatrix, ascending: false);

            jagged = toJagged(testMatrix);
            Assert.AreEqual(testMatrix, to2d(jagged.OrderBy(row => -row.Max()).ToArray()));
        }

        [Test]
        public void MinSortTest()
        {
            sorter.IsLessStrategy = matrix_sort.SortOrders.MinIsLess;

            int[][] jagged;
            sorter.SortMatrix(testMatrix, ascending: true);

            jagged = toJagged(testMatrix);
            Assert.AreEqual(testMatrix, to2d(jagged.OrderBy(row => row.Min()).ToArray()));

            sorter.SortMatrix(testMatrix, ascending: false);

            jagged = toJagged(testMatrix);
            Assert.AreEqual(testMatrix, to2d(jagged.OrderBy(row => -row.Min()).ToArray()));
        }
    }
}