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
                { 3, 0, 0},
                { 0, 4, 0},
                { 0, 0, 6}
            });
            int expected = 13;

            int actual = matrix.DiagonaSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonaSum_WithValidRectangleRightMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 3, 0, 0, 0, 0},
                { 0, 4, 0, 0, 0},
                { 0, 0, 6, 0, 0}
            });
            int expected = 13;

            int actual = matrix.DiagonaSum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonaSum_WithValidRectangleDownMatrix_ShouldReturnExpectedValue()
        {
            Matrix matrix = new(new byte[,]
            {
                { 3, 0, 0},
                { 0, 4, 0},
                { 0, 0, 6},
                { 0, 0, 0},
                { 0, 0, 0}
            });
            int expected = 13;

            int actual = matrix.DiagonaSum();

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
    }
}