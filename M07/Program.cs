using System;

namespace M07
{
    delegate int[,] MyDelegate(int[,] twoDimensional, BubbleSort.TypeOfComparison comparisonType, BubbleSort.TypeOfOrder orderType);

    public interface IBubbleSortStrategy
    {
        public BubbleSort.TypeOfComparison ComparisonType { get; set; }
        public BubbleSort.TypeOfOrder OrderType { get; set; }
    }
    public class TestExtremumSort : IBubbleSortStrategy
    {
        public BubbleSort.TypeOfComparison ComparisonType { get; set; }
        public BubbleSort.TypeOfOrder OrderType { get; set; }

        public TestExtremumSort()
        {
            ComparisonType = BubbleSort.TypeOfComparison.Ascending;
            OrderType = BubbleSort.TypeOfOrder.Maximum;
        }
    }
    public class TestSumSort : IBubbleSortStrategy
    {
        public BubbleSort.TypeOfComparison ComparisonType { get; set; }
        public BubbleSort.TypeOfOrder OrderType { get; set; }

        public TestSumSort()
        {
            ComparisonType = BubbleSort.TypeOfComparison.Descending;
            OrderType = BubbleSort.TypeOfOrder.Sum;
        }
    }

    class Program
    {
        private static Random random = new Random();

        static void Main()
        {
            var lenght = random.Next(3, 3);
            var height = random.Next(3, 3);
            var matrix = new int[lenght, height];
            FillDemoMatrix(matrix);
            Console.WriteLine("DemoMatrix:");
            PrintMatrix(matrix);



            Console.WriteLine("Result of Bubble Sorting in Ascending order by Sums of matrix elements:");

            var testExtremumSort = new TestExtremumSort();
            var newSort = new BubbleSort(matrix, testExtremumSort);
            var newMatrix =  newSort.BubbleSortByRowsExtremum();
            PrintMatrix(newMatrix);
        }

        public static void FillDemoMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(1, 20);
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}