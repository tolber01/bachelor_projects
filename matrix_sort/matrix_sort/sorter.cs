using System;

namespace matrix_sort
{
    public class MatrixSorter
    {
        private IsLessFunc IsLess;
        private Random rnd;

        public MatrixSorter()
        {
            rnd = new Random();
        }

        public IsLessFunc IsLessStrategy
        {
            set { IsLess = value; }
        }

        public void SortMatrix(int[,] matrix, bool ascending = true)
        {
            QuickSort(matrix, 0, matrix.GetLength(0) - 1, reverseOrder: !ascending);
        }

        private void QuickSort(int[,] matrix, int begin, int end, bool reverseOrder)
        {
            if (begin >= end)
                return;

            int pivotIdx = rnd.Next(begin, end + 1);
            int i = begin, j = end;
            while (i <= j)
            {
                while (IsLess(matrix, reverseOrder ? pivotIdx : i, reverseOrder ? i : pivotIdx))  // is row_i < row_pivotIdx or not?
                    i++;
                while (IsLess(matrix, reverseOrder ? j : pivotIdx, reverseOrder ? pivotIdx : j))  // is row_j > row_pivotIdx or not?
                    j--;
                if (i >= j)
                    break;
                SwapRows(matrix, i++, j--);
            }

            QuickSort(matrix, begin, j, reverseOrder);
            QuickSort(matrix, j + 1, end, reverseOrder);
        }

        private void SwapRows(int[,] matrix, int i, int j)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                int t = matrix[i, k];
                matrix[i, k] = matrix[j, k];
                matrix[j, k] = t;
            }
        }
    }
}
