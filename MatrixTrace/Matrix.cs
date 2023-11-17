using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MatrixTrace
{
    public class Matrix
    {
        private ushort _rows;
        private ushort _columns;
        private byte[,] _matrix;

        public ushort Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
        public ushort Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
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
        public byte[,] GetMatrix()
        {
            byte[,] matrix = new byte[_rows, _columns];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    matrix[i, j] = _matrix[i, j];
                }
            }

            return matrix; 
        }
        public void SetMatrix(byte[,] matrix)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _matrix[i, j]= matrix[i, j];
                }
            }
        }

        public Matrix(ushort rows, ushort columns)
        {
            if (rows == 0 || columns == 0)
                throw new Exception("Matrix dimensions must be greater than 0");
  
            _rows = rows;
            _columns = columns;
            _matrix = new byte[rows,columns];
        }

        public Matrix(byte[,] matrix)
        {
            _matrix = matrix ?? throw new ArgumentNullException(nameof(matrix), "The matrix cannot be null");
            _rows = (ushort)_matrix.GetLength(0);
            _columns = (ushort)_matrix.GetLength(1);
        }

        /// <summary>
        /// Fills the matrix in the selected range from 0 to 255
        /// </summary>
        public void FillMatrixRandomNumbersInRange(int min, int max)
        {
            Random random = new();

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _matrix[i, j] += (byte)random.Next(min, max);
                }
            }
        }
    }
}
