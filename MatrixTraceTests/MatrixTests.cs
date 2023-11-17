using MatrixTrace;

namespace MatrixTraceTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void DiagonaSum_WithValidSquareMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 11, 12, 13},
                { 21, 22, 23},
                { 31, 32, 33}
            });
            int expected = 66;

            int actual = matrix.DiagonalSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonaSum_WithValidRectangleRightMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 11, 12, 13, 14, 15},
                { 21, 22, 23, 24, 25},
                { 31, 32, 33, 34, 35}
            });
            int expected = 66;

            int actual = matrix.DiagonalSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalSum_WithValidRectangleDownMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 11, 12, 13},
                { 21, 22, 23},
                { 31, 32, 33 },
                { 41, 42, 43},
                { 51, 52, 53}
            });
            int expected = 66;

            int actual = matrix.DiagonalSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ElementsFormOfSnake_WithValidnMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
            {1, 2, 3, 4 },
            {8, 7, 6, 5 },
            {4, 3, 2, 9 }
            });
            List<byte> expected = new() { 1, 2, 3, 4, 5, 9, 2, 3, 4, 8, 7, 6 };

            List<byte> actual = matrix.ElementsFormOfSnake();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ElementsFormOfSnake_WithValidnMatrixSquare5x5_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
            {1, 2, 3, 4, 5 },
            {12, 13, 14, 15, 6 },
            {11, 10, 9, 8, 7 }
            });
            List<byte> expected = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            List<byte> actual = matrix.ElementsFormOfSnake();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ElementsFormOfSnake_WithValidnMatrixRectangle3x6_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
            {1, 2, 3, 4, 5, 6 },
            {14, 15, 16, 17, 18, 7 },
            {13, 12, 11, 10, 9, 8 }
            });
            List<byte> expected = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            List<byte> actual = matrix.ElementsFormOfSnake();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ElementsFormOfSnake_WithValidnMatrixRectangle7x2_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
            {1, 2 },
            {14, 3},
            {13, 4 },
            {12, 5 },
            {11, 6 },
            {10, 7 },
            {9, 8 }
            });
            List<byte> expected = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            List<byte> actual = matrix.ElementsFormOfSnake();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}