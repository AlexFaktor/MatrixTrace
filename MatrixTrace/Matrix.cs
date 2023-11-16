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
        public byte[,] GetMatrix()
        { return _matrix; }
        public void SetMatrix(byte[,] value)
        { _matrix = value; }

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
    }
}
