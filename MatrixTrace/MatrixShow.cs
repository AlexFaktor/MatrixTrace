using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public static class MatrixShow
    {
        /// <summary>
        /// Displays the diagonal of the matrix in the console 
        /// </summary>
        public static void ShowDiagonal(Matrix inputMatrix)
        {
            int rows = inputMatrix.Rows;
            int columns = inputMatrix.Columns;
            byte[,] matrix = inputMatrix.GetMatrix();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matrix[i, j].ToString("000") + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(matrix[i, j].ToString("000") + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
