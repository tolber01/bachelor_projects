using System;

namespace matrix_sort
{
    public delegate bool IsLessFunc(int[,] matrix, int i, int j);

    public class SortOrders
    {
        public static bool SumIsLess(int[,] matrix, int i, int j)
        {
            int sumI = 0, sumJ = 0;
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                sumI += matrix[i, k];
                sumJ += matrix[j, k];
            }

            return sumI < sumJ;
        }

        public static bool MaxIsLess(int[,] matrix, int i, int j)
        {
            int maxI = matrix[i, 0], maxJ = matrix[j, 0];
            for (int k = 1; k < matrix.GetLength(1); k++)
            {
                maxI = Math.Max(maxI, matrix[i, k]);
                maxJ = Math.Max(maxJ, matrix[j, k]);
            }

            return maxI < maxJ;
        }

        public static bool MinIsLess(int[,] matrix, int i, int j)
        {
            int minI = matrix[i, 0], minJ = matrix[j, 0];
            for (int k = 1; k < matrix.GetLength(1); k++)
            {
                minI = Math.Min(minI, matrix[i, k]);
                minJ = Math.Min(minJ, matrix[j, k]);
            }

            return minI < minJ;
        }
    }
}
