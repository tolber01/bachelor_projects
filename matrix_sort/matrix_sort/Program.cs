using System;

namespace matrix_sort
{
    class Program
    {
        private enum CharCodes
        {
            BySum = '1',
            ByMax = '2',
            ByMin = '3',
            Asc = '1',
            Desc = '2'
        }
        private static string ORDER_TYPE_MSG = $"Choose rows sorting type:\r\n{(char)CharCodes.BySum} - by sum\r\n{(char)CharCodes.ByMax} - by max\r\n{(char)CharCodes.ByMin} - by min";
        private static string SORT_TYPE_MSG = $"Choose type of sorting:\r\n{(char)CharCodes.Asc} - ascending\r\n{(char)CharCodes.Desc} - descending";

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
                { 11, -14,  5,  6 }, // sum = 8, max = 11, min = -14
                {  1,   3, -2, -1 }, // sum = 1, max = 3, min = -2
                {  0,  -3, -5,  3 }, // sum = -4, max = 3, min = -5
                {  1,  -1,  2, -2 }  // sum = 0, max = 2, min = -2
            };

            char orderType;
            do
            {
                Console.Clear();
                Console.WriteLine(ORDER_TYPE_MSG);
                orderType = Console.ReadKey(true).KeyChar;
            } while (orderType != (char)CharCodes.BySum
                  && orderType != (char)CharCodes.ByMax
                  && orderType != (char)CharCodes.ByMin);

            switch (orderType)
            {
                case (char)CharCodes.BySum:
                    sorter.IsLessStrategy = SortOrders.SumIsLess;
                    break;
                case (char)CharCodes.ByMax:
                    sorter.IsLessStrategy = SortOrders.MaxIsLess;
                    break;
                case (char)CharCodes.ByMin:
                    sorter.IsLessStrategy = SortOrders.MinIsLess;
                    break;
            };

            orderType = '0';
            do
            {
                Console.Clear();
                Console.WriteLine(SORT_TYPE_MSG);
                orderType = Console.ReadKey(true).KeyChar;
            } while (orderType != (char)CharCodes.Asc && orderType != (char)CharCodes.Desc);

            sorter.SortMatrix(matrix, ascending: orderType == (char)CharCodes.Asc);

            Console.Clear();
            Console.WriteLine("Sorted matrix:");
            PrintMatrix(matrix);
        }
    }
}
