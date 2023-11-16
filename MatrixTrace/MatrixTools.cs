using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class MatrixTools
    {
        /// <summary>
        /// Fills the matrix in the selected range from 0 to 255
        /// </summary>
        public static void FillMatrixRandomNumbersInRange(Matrix inputMatrix, int min, int max)
        {
            int rows = inputMatrix.Rows;
            int columns = inputMatrix.Columns;
            byte[,] matrix = inputMatrix.GetMatrix();

            Random random = new();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] += (byte)random.Next(min, max);
                }
            }
        }


        /// <summary>
        /// Returns the sum of the elements on the diagonal of the matrix
        /// </summary>
        public static int DiagonalSum(Matrix inputMatrix)
        {
            int rows = inputMatrix.Rows;
            int columns = inputMatrix.Columns;
            byte[,] matrix = inputMatrix.GetMatrix();

            int sum = 0;

            int minSize = Math.Min(rows, columns);

            for (int i = 0; i < minSize; i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        /// <summary>
        /// From the selected position, from left to right, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsLeftToRight(byte[,] matrix, int[]position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0], position[1] + i];
            }
        }
        /// <summary>
        /// From the selected position, from top to bottom, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsUpToDown(byte[,] matrix, int[] position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0] + i , position[1]];
            }
        }
        /// <summary>
        /// From the selected position, from right to left, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsRightToLeft(byte[,] matrix, int[] position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0], position[1] - i];
            }
        }
        /// <summary>
        /// From the selected position, from right to left, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsDownToUp(byte[,] matrix, int[] position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0] - i, position[1]];
            }
        }
        /// <summary>
        /// Returns a list of matrix elements in the form of a snake
        /// </summary>s>
        public static List<byte> ElementsFormOfSnake(Matrix inputMatrix)
        {
            byte[,] matrix = inputMatrix.GetMatrix();

            int sumOfAllElements = inputMatrix.GetMatrix().Length;
            int addedElements = 0;

            int[] position = new int[] { 0, 0 };

            int forRows = inputMatrix.Rows - 2;
            int forColumns = inputMatrix.Columns;

            List<byte> output = new();

            while (true)
            {
                // LtR
                if (forColumns > 0)
                {
                    output.AddRange(ElementsLeftToRight(matrix, position, forColumns));
                    position[1] += forColumns - 1;
                    addedElements += forColumns;

                    position[0] = position[0] + 1;
                }
                if (addedElements == sumOfAllElements)
                    break;
                    
                // UtD
                if (forRows > 0)
                {
                    output.AddRange(ElementsUpToDown(matrix, position, forRows));
                    position[0] += forRows - 1;
                    addedElements += forRows;

                    position[0] = position[0] + 1;
                }
                if (addedElements == sumOfAllElements)
                    break;
     
                // RtL
                if (forColumns > 0)
                {
                    output.AddRange(ElementsRightToLeft(matrix, position, forColumns));
                    position[1] -= forColumns - 1;
                    addedElements += forColumns;

                    position[0] = position[0] - 1;
                }
                
                if (addedElements == sumOfAllElements)
                    break;

                forColumns -= 2;
                    
                // DtU
                if (forRows > 0)
                {
                    output.AddRange(ElementsDownToUp(matrix, position, forRows));
                    position[0] -= forRows - 1;
                    addedElements += forRows;

                    position[1] = position[1] + 1;
                }
                
                if (addedElements == sumOfAllElements)
                    break;

                forRows -= 2;
            }

            return output;
        }
    }
}
