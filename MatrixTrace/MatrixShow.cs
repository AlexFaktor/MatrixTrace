namespace MatrixTrace
{
    public static class MatrixShow
    {
        /// <summary>
        /// Displays the diagonal of the matrix in the console 
        /// </summary>
        public static void ShowDiagonal(Matrix matrix)
        {
            int rows = matrix.RowCount;
            int columns = matrix.ColumnCount;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{matrix[i, j],4}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j],4}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
