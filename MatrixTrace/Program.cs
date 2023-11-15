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
                var input = Console.ReadLine();
                if (ushort.TryParse(input, out rows))
                {
                    Console.Clear();
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter the number of columns: ");
                var input = Console.ReadLine();
                if (ushort.TryParse(input, out columns))
                {
                    Console.Clear();
                    break;
                }
                
            }          

            Console.WriteLine($"Matrix size: {rows} x {columns}\n");

            Matrix matrixObj = new(rows, columns);
            matrixObj.DiagonalShow();

            Console.WriteLine($"\nSum of elements on the diagonal: {matrixObj.DiagonaSum()}");
            Console.WriteLine($"List of elements in the form of a snake: ");

            for (int i = 0; i < (rows * columns); i++)
            {
                Console.Write(matrixObj.ElementsFormOfSnake()[i] + " ");
            }
        }
    }
}