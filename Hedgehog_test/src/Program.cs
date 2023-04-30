namespace Hedgehog_test.src
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[] { 20, 71, 0 };
            int color = 0;

            Run(arr, color);
        }


        static void Run(int[] arr, int color)
        {

            int n = Processor.Start(arr, color);
            Console.WriteLine($"Количество встреч: {n}");
            Console.WriteLine($"Шагов: {Processor.Steps}");

            if (n != -1)
            {
                Console.WriteLine($"Состояния:\n");
                Methods.PrintList(Processor.Way);

            }




        }

    }
}
