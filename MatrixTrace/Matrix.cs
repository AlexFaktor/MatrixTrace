using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class Matrix
    {
        private ushort rows;
        private ushort columns;
        private byte[,] matrix;

        public Matrix(ushort _rows, ushort _columns)
        {
            rows = _rows;
            columns = _columns;
            matrix = FilledMatrixWithDimensions(rows, columns);
        }

        /// <summary>
        /// Fills a matrix from 0 to 100 with random numbers of specified sizes, and then returns it
        /// </summary>
        public static byte[,] FilledMatrixWithDimensions(ushort rows, ushort columns)
        {
            byte[,] matrix = new byte[rows, columns];
            Random random = new();

            for (int i = 0; i < rows; i++)
            { 
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = (byte)random.Next(0, 101);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Displays the diagonal of the matrix in the console 
        /// </summary>
        public void DiagonalShow()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(i == j)
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

        /// <summary>
        /// Returns the sum of matrix elements
        /// </summary>
        public int DiagonaSum()
        {
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                        sum += matrix[i, j];
                } 
            }

            return sum;
        }
    }
}
