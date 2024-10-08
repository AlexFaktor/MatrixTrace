﻿namespace MatrixTrace
{
    public class Matrix
    {
        private readonly ushort _rowCount;
        private readonly ushort _columnCount;
        private byte[,] _matrix;

        public ushort RowCount => _rowCount;
        public ushort ColumnCount => _columnCount;

        public byte this[int row, int column]
        {
            get
            {
                return _matrix[row, column];
            }
            set
            {
                _matrix[row, column] = value;
            }
        }

        public Matrix(ushort rows, ushort columns)
        {
            if (rows == 0 || columns == 0)
                throw new ArgumentException("Matrix dimensions must be greater than 0");

            _rowCount = rows;
            _columnCount = columns;
            _matrix = new byte[rows, columns];
        }

        public Matrix(byte[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "The matrix cannot be null");
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                throw new ArgumentException(nameof(matrix), "Size cant be 0");

            _rowCount = (ushort)matrix.GetLength(0);
            _columnCount = (ushort)matrix.GetLength(1);
            _matrix = new byte[_rowCount, _columnCount];

            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
        }

        /// <summary>
        /// Returns the sum of the elements on the diagonal of the matrix
        /// </summary>
        public int DiagonalSum()
        {
            int sum = 0;

            int minSize = Math.Min(_rowCount, _columnCount);

            for (int i = 0; i < minSize; i++)
            {
                sum += this[i, i];
            }

            return sum;
        }

        /// <summary>
        /// From the selected position, from left to right, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsLeftToRight(Matrix matrix, System.Drawing.Point position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position.X, position.Y + i];
            }
        }

        /// <summary>
        /// From the selected position, from top to bottom, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsUpToDown(Matrix matrix, System.Drawing.Point position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position.X + i, position.Y];
            }
        }

        /// <summary>
        /// From the selected position, from right to left, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsRightToLeft(Matrix matrix, System.Drawing.Point position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position.X, position.Y - i];
            }
        }

        /// <summary>
        /// From the selected position, from right to left, returns the selected number of items
        /// </summary>
        private static IEnumerable<byte> ElementsDownToUp(Matrix matrix, System.Drawing.Point position, int step)
        {
            for (int i = 0; i < step; i++)
            {
                yield return matrix[position.X - i, position.Y];
            }
        }

        /// <summary>
        /// Returns a list of matrix elements in the form of a snake
        /// </summary>s>
        public List<byte> ElementsFormOfSnake()
        {
            int sumOfAllElements = _rowCount * _columnCount;
            int addedElements = 0;

            System.Drawing.Point position = new(0, 0);

            int forRows = _rowCount - 2;
            int forColumns = _columnCount;

            List<byte> output = new();

            while (true)
            {
                // LtR
                if (forColumns > 0)
                {
                    output.AddRange(ElementsLeftToRight(this, position, forColumns));
                    position.Y += forColumns - 1;
                    addedElements += forColumns;

                    position.X++;
                }
                if (addedElements == sumOfAllElements)
                    break;

                // UtD
                if (forRows > 0)
                {
                    output.AddRange(ElementsUpToDown(this, position, forRows));
                    position.X += forRows - 1;
                    addedElements += forRows;

                    position.X++;
                }
                if (addedElements == sumOfAllElements)
                    break;

                // RtL
                if (forColumns > 0)
                {
                    output.AddRange(ElementsRightToLeft(this, position, forColumns));
                    position.Y -= forColumns - 1;
                    addedElements += forColumns;

                    position.X--;
                }

                if (addedElements == sumOfAllElements)
                    break;

                forColumns -= 2;

                // DtU
                if (forRows > 0)
                {
                    output.AddRange(ElementsDownToUp(this, position, forRows));
                    position.X -= forRows - 1;
                    addedElements += forRows;

                    position.Y++;
                }

                if (addedElements == sumOfAllElements)
                    break;

                forRows -= 2;
            }

            return output;
        }
    }
}
