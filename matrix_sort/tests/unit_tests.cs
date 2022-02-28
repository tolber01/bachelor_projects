using NUnit.Framework;

namespace tests
{
    public class Tests
    {
        private int[,] testMatrix;
        private matrix_sort.MatrixSorter sorter;

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

            sorter.SortMatrix(testMatrix, ascending: true);
            Assert.AreEqual(testMatrix, new int[,] {
                { 1, 2, 3, -4, -5, -6 },
                { 12, -5, -8, -9, 3, 5 },
                { -1, 2, -5, 6, 7, 0 },
                { 0, 4, 6, 8, -1, -3 },
            });

            sorter.SortMatrix(testMatrix, ascending: false);
            Assert.AreEqual(testMatrix, new int[,] {
                { 0, 4, 6, 8, -1, -3 },
                { -1, 2, -5, 6, 7, 0 },
                { 12, -5, -8, -9, 3, 5 },
                { 1, 2, 3, -4, -5, -6 },
            });
        }
    }
}