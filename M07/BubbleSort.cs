using System;

namespace M07
{
    public class BubbleSort
    {
        public IBubbleSortStrategy SortStrategy { get; private set; }
        public TypeOfComparison ComparisonType { get; private set; }
        public TypeOfOrder OrderType { get; private set; }
        public int[,] Matrix { get; private set; }

        public BubbleSort(int[,] matrix, IBubbleSortStrategy sortStrategy)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            Matrix = matrix;
            ComparisonType = sortStrategy.ComparisonType;
            OrderType = sortStrategy.OrderType;

        }

        public int[,] BubbleSortByRowsSum()
        {
            var rowSummArray = new int[Matrix.GetLength(0)];
            var sum = 0;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    sum += Matrix[i, j];
                }

                rowSummArray[i] = sum;
                sum = 0;
            }

            return RowsBubbleSort(rowSummArray);
        }

        public int[,] BubbleSortByRowsExtremum()
        {
            var extremums = new int[Matrix.GetLength(0)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                var extremum = Matrix[i, 0];

                for (int j = 0; j < Matrix.GetLength(1) - 1; j++)
                {
                    if (OrderType == TypeOfOrder.Maximum)
                    {
                        if (extremum < Matrix[i, j + 1])
                        {
                            extremum = Matrix[i, j + 1];
                        }
                    }
                    else
                    {
                        if (extremum > Matrix[i, j + 1])
                        {
                            extremum = Matrix[i, j + 1];
                        }
                    }
                }

                extremums[i] = extremum;
            }

            return RowsBubbleSort(extremums);
        }

        private int[,] RowsBubbleSort(int[] rows)
        {
            if (Matrix == null || rows == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < rows.Length - 1; i++)
            {
                for (int j = 1; j < rows.Length; j++)
                {
                    if ((ComparisonType == TypeOfComparison.Ascending && rows[i] > rows[j]) ||
                        (ComparisonType == TypeOfComparison.Descending && rows[i] < rows[j]))
                    {
                        SwapRows(i, j);
                    }
                }
            }

            return Matrix;
        }

        private void SwapRows(int firstString, int secondString)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                var a = Matrix[firstString, j];
                Matrix[firstString, j] = Matrix[secondString, j];
                Matrix[secondString, j] = a;
            }
        }

        public enum TypeOfComparison
        {
            Ascending,
            Descending
        }

        public enum TypeOfOrder
        {
            Maximum,
            Minimum,
            Sum
        }
    }
}
