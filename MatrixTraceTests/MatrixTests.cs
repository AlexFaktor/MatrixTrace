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
                { 1, 10, 21},
                { 5, 30, 42},
                { 9, 59, 83}
            });
            int expected = 114;

            int actual = matrix.DiagonalSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonaSum_WithValidRectangleRightMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 1, 10, 21, 43, 100},
                { 5, 30, 42, 56, 200},
                { 9, 59, 83, 69, 230}
            });
            int expected = 114;

            int actual = matrix.DiagonalSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalSum_WithValidRectangleDownMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 1, 10, 21},
                { 5, 30, 42},
                { 9, 59, 83 },
                { 13, 75, 160},
                { 17, 100, 240}
            });
            int expected = 114;

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
            {16, 17, 18, 19, 6 },
            {15, 24, 25, 20, 7 },
            {14, 23, 22, 21, 8 },
            {13, 12, 11, 10, 9 }
            });
            List<byte> expected = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

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