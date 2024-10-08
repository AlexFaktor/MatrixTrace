﻿namespace MatrixTrace
{
    public static class MatrixTools
    {
        /// <summary>
        /// Fills the matrix in the selected range from 0 to 255
        /// </summary>
        public static void FillRandomNumbersInRange(this Matrix matrix, int min, int max)
        {
            Random random = new();

            int rowCount = matrix.RowCount;
            int columnCount = matrix.ColumnCount;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = (byte)random.Next(min, max);
                }
            }
        }
    }
}
