using System;

namespace matrix_sort
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var sorter = new MatrixSorter();
            var matrix = new int[,] {
                { 11, -14, 5, 6 }, // sum = 8, max = 11, min = -14
                { 1, 3, -2, -1 },  // sum = 1, max = 3, min = -2
                { 0, -3, -5, 3 }, // sum = -4, max = 3, min = -5
                { 1, -1, 2, -2 } // sum = 0, max = 2, min = -2
            };

            Console.WriteLine("Sorted rows by sum (ascending):");
            sorter.IsLessStrategy = SortOrders.SumIsLess;
            sorter.SortMatrix(matrix);
            PrintMatrix(matrix);

            Console.WriteLine("\nSorted rows by max (descending):");
            sorter.IsLessStrategy = SortOrders.MaxIsLess;
            sorter.SortMatrix(matrix, ascending: false);
            PrintMatrix(matrix);

            Console.WriteLine("\nSorted rows by min (ascending):");
            sorter.IsLessStrategy = SortOrders.MinIsLess;
            sorter.SortMatrix(matrix);
            PrintMatrix(matrix);
        }
    }
}
