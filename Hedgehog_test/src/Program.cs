namespace Hedgehog_test.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 20, 71, 71 };
            int color = 0;

            Console.WriteLine(Processor.Start(arr, color));
        }

    }
}
