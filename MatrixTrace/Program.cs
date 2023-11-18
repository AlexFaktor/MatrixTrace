namespace MatrixTrace
{
    internal class Program
    {
        public static int InputNumber(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int output))
                    return output;
            }
        }

        static void Main()
        {
            var rowCount = InputNumber("Enter the number of rows: ");
            var columnCount = InputNumber("Enter the number of columns: ");

            Console.Clear();
            Console.WriteLine($"Matrix size: {rowCount} x {columnCount}\n");

            Matrix matrix = new((ushort)rowCount, (ushort)columnCount);

            matrix.FillRandomNumbersInRange(0, 101);

            MatrixShow.ShowDiagonal(matrix);

            Console.WriteLine($"\nSum of elements on the diagonal: {matrix.DiagonalSum()}");
            Console.WriteLine($"List of elements in the form of a snake: ");

            List<byte> snake = matrix.ElementsFormOfSnake();

            foreach (byte el in snake)
            {
                Console.Write(el + " ");
            }
        }
    }
}