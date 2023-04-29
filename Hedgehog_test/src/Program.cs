namespace Hedgehog_test.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Run(new int[] { 20, 71, 55 }, 0));
        }

        private static int Run(int[] arr, int color)
        {
            return new Processor(arr, color).Start();
        }
    }
}
