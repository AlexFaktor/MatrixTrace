namespace MatrixTrace
{
    internal class Program
    {
        static void Main()
        {
            ushort rows;
            ushort columns;

            while (true)
            {
                Console.WriteLine("Enter the number of rows: ");
                var inputRows = Console.ReadLine();
                Console.WriteLine("Enter the number of columns: ");
                var inputColumns = Console.ReadLine();

                if (ushort.TryParse(inputRows, out rows ) && ushort.TryParse(inputColumns, out columns))
                {
                    Console.Clear();
                    break;
                }
            }

            Console.WriteLine($"Matrix size: {rows} x {columns}\n");

            Matrix matrix = new(rows, columns);

            MatrixTools.FillMatrixRandomNumbersInRange(matrix, 0, 101);

            MatrixShow.ShowDiagonal(matrix);

            Console.WriteLine($"\nSum of elements on the diagonal: {MatrixTools.DiagonalSum(matrix)}");
            Console.WriteLine($"List of elements in the form of a snake: ");

            List<byte> snake = MatrixTools.ElementsFormOfSnake(matrix);

            foreach (byte el in snake)
            { 
                Console.Write(el + " ");
            }
        }
    }
}