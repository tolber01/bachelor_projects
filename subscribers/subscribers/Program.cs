using System;

namespace subscribers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input file path for FileWriter: ");
            string filePath = Console.ReadLine();
            Console.Clear();
            int timeMs;
            do
            {
                Console.Clear();
                Console.WriteLine("Input timer timeout (in ms): ");
            } while (!int.TryParse(Console.ReadLine(), out timeMs));

            var t = new Countdown();
            var subs1 = new Logger();
            var subs2 = new Logger();
            var subs3 = new FileWriter(filePath, rewrite: false);

            t.AddSubscriber(subs1);
            t.AddSubscriber(subs2);
            t.AddSubscriber(subs3);

            t.RunTimer("First try!", timeMs);
            t.RunTimer("Second try!", timeMs);
            t.RemoveSubscriber(subs3);
            t.RunTimer("Last try!", timeMs);

            Console.WriteLine("\nFirst subscriber's logs:");
            subs1.PrintLogs();

            Console.WriteLine("\nSecond subscriber's logs:");
            subs2.PrintLogs();

            Console.WriteLine($"\nFile '{filePath}' contents:");
            Console.WriteLine(subs3.ReadFile());
        }
    }
}
