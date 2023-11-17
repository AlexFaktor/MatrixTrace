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
        /// Returns the sum of the elements on the diagonal of the matrix
        /// </summary>
        public static int DiagonalSum(Matrix matrix)
        {
            int sum = 0;

            int minSize = Math.Min(matrix.Rows, matrix.Columns);

            for (int i = 0; i < minSize; i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        /// <summary>
        /// From the selected position, from left to right, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsLeftToRight(Matrix matrix, int[]position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0], position[1] + i];
            }
        }

        /// <summary>
        /// From the selected position, from top to bottom, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsUpToDown(Matrix matrix, int[] position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0] + i , position[1]];
            }
        }

        /// <summary>
        /// From the selected position, from right to left, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsRightToLeft(Matrix matrix, int[] position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0], position[1] - i];
            }
        }

        /// <summary>
        /// From the selected position, from right to left, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsDownToUp(Matrix matrix, int[] position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position[0] - i, position[1]];
            }
        }

        /// <summary>
        /// Returns a list of matrix elements in the form of a snake
        /// </summary>s>
        public static List<byte> ElementsFormOfSnake(Matrix matrix)
        {
            int sumOfAllElements = matrix.GetMatrix().Length;
            int addedElements = 0;

            int[] position = new int[] { 0, 0 };

            int forRows = matrix.Rows - 2;
            int forColumns = matrix.Columns;

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
