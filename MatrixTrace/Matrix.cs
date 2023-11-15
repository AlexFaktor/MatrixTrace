using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class Matrix
    {
        private readonly ushort rows;
        private readonly ushort columns;
        private readonly byte[,] matrix;

        public Matrix(ushort _rows, ushort _columns)
        {
            if (_rows == 0 || _columns == 0)
                throw new Exception("Matrix dimensions must be greater than 0");
                
            rows = _rows;
            columns = _columns;
            matrix = FilledMatrixWithDimensions(rows, columns);
        }

        public Matrix(byte[,] _matrix)
        { 
            if (_matrix == null)
                throw new Exception("The matrix cannot be null");

            rows = (ushort) _matrix.GetLength(0);
            columns = (ushort) _matrix.GetLength(1);
            matrix = _matrix;
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

        /// <summary>
        /// Returns a list of elements in a row, from to, from left to right
        /// </summary>
        private List<byte> ElementsLeftToRight(int row, int columnFrom, int columnTo)
        {
            List<byte> output = new();

            for (int i = columnFrom; i <= columnTo; i++)
            {
                output.Add(matrix[row, i]);
            }

            return output;
        }

        /// <summary>
        /// Returns a list of elements in a column, from to, from top to bottom
        /// </summary>
        private List<byte> ElementsUpToDown(int column, int rowFrom, int rowTo)
        {
            List<byte> output = new();

            for (int i = rowFrom; i <= rowTo; i++)
            {
                output.Add(matrix[i, column]);
            }

            return output;
        }

        /// <summary>
        /// Returns a list of elements in a row, from to, from right to left
        /// </summary>
        private List<byte> ElementsRightToLeft(int row, int columnFrom, int columnTo)
        {
            List<byte> output = new();

            for (int i = columnFrom; i >= columnTo; i--)
            {
                output.Add(matrix[row, i]);
            }

            return output;
        }

        /// <summary>
        /// Returns a list of elements in a column, from to, from bottom to top
        /// </summary>
        private List<byte> ElementsDownToUp(int column, int rowFrom, int rowTo)
        {
            List<byte> output = new();

            for (int i = rowFrom; i >= rowTo; i--)
            {
                output.Add(matrix[i, column]);
            }

            return output;
        }

        /// <summary>
        /// Returns a list of matrix elements in the form of a snake, starting from the top left
        /// </summary>
        public List<byte> ElementsFormOfSnake()
        {
            int sumOfAllElements = rows * columns;
            int addedElements = 0;

            List<byte> output = new();

            // these variables are used as the initial parameters of each matrix, which are needed for the functions
            // in some cases, -1 is required due to the specifics of array/list operation
            int ElmLtRRow = 0;
            int ElmLtRFrom = 0;
            int ElmLtRTo = columns - 1;

            int ElmUtDColumn = columns -1;
            int ElmUtDFrom = 0 + 1;
            int ElmUtDTo = rows - 1 - 1;

            int ElmRtLRow = rows - 1;
            int ElmRtLFrom = columns - 1;
            int ElmRtLTo = 0;

            int ElmDtUColumn = 0;
            int ElmDtUFrom = rows - 1 - 1;
            int ElmDtUTo = 0 + 1;
            //

            while (true)
            {
                var ElmLtR = ElementsLeftToRight(ElmLtRRow, ElmLtRFrom, ElmLtRTo);
                if (ElmLtR.Count > 0)
                {
                    output.AddRange(ElmLtR);
                    addedElements += ElmLtR.Count;
                    ElmLtRRow++;
                    ElmLtRFrom++;
                    ElmLtRTo--;
                }
                if (addedElements == sumOfAllElements)
                    break;

                var ElmUtD = ElementsUpToDown(ElmUtDColumn, ElmUtDFrom, ElmUtDTo);
                if (ElmUtD.Count > 0)
                {
                    output.AddRange(ElmUtD);
                    addedElements += ElmUtD.Count;
                    ElmUtDColumn--;
                    ElmUtDFrom++;
                    ElmUtDTo--;
                }
                if (addedElements == sumOfAllElements)
                    break;

                var ElmRtL = ElementsRightToLeft(ElmRtLRow, ElmRtLFrom, ElmRtLTo);
                if (ElmRtL.Count > 0)
                {
                    output.AddRange(ElmRtL);
                    addedElements += ElmRtL.Count;
                    ElmRtLRow--;
                    ElmRtLFrom--;
                    ElmRtLTo++;
                }
                if (addedElements == sumOfAllElements)
                    break;

                var ElmDtU = ElementsDownToUp(ElmDtUColumn, ElmDtUFrom, ElmDtUTo);
                if (ElmDtU.Count > 0)
                {
                    output.AddRange(ElmDtU);
                    addedElements += ElmDtU.Count;
                    ElmDtUColumn++;
                    ElmDtUFrom--;
                    ElmDtUTo++;
                }
                if (addedElements == sumOfAllElements)
                    break;
            }

            return output; 
        }
    }
}
