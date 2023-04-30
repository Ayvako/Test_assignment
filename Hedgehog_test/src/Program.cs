namespace Hedgehog_test.src
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[] { 20, 71, 71 };
            int color = 0;

            Run(arr, color);
        }


        static void Run(int[] arr, int color)
        {



            Console.WriteLine($"Количество встреч: {Processor.Start(arr, color)}");
            Console.WriteLine($"Шагов: {Processor.Steps}");

            Console.WriteLine($"Состояния:\n");
            Methods.PrintList(Processor.Way);

        }

    }
}
