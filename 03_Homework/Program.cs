using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Net;
using System.Text;
using System.Text.Unicode;

internal class Program
{
    public class Fibonacci
    {
        public Fibonacci(int N1, int N2)
        {
            n1 = N1;
            n2 = N2;
        }

        public int n1 { get; set; }
        public int n2 { get; set; }
        private int res { get; set; }
        public int EvenCounter { get; set; }
        public int Iteration { get; set; } = 1;
        public void Logic()
            {
            for (int j = 0; j < 10; j++)
                {

                    lock (this)
                    {
                        if (n1 % 2 == 0)
                            EvenCounter++;
                        if (n2 % 2 == 0)
                            EvenCounter++;

                    Console.WriteLine($"{Iteration}\t\t{n1}\t{n2}\t{EvenCounter}");

                        res = n1 + n2;
                        n1 = n2;
                        n2 = res;
                        Iteration++;
                    }
                }
            }

    }
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ви хочете розпочати роботу програми? (yes/no)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    Console.WriteLine("Ведіть перше початковe число :: ");
                    int n1;
                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out n1))
                        {
                            Console.WriteLine("Число не коректне спробуйте ще раз ::");
                        }
                        else
                            break;
                    }
                    Console.WriteLine("Ведіть друге початковe число :: ");
                    int n2;
                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out n2))
                        {
                            Console.WriteLine("Число не коректне");
                        }
                        else
                            break;
                    }

                    Console.WriteLine($"Ітерпції\tn1\tn2\tEvenCounter");
                    FibonacciCounter(n1, n2);
                    return;
                case "no":
                    Console.WriteLine("Програма завершила свою роботу!");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("Ведено не коректна відповідь спробуйте ще");
                    break;
            }
        }
    }
    static public void FibonacciCounter(int n1, int n2)
    {
        Fibonacci f = new Fibonacci(n1, n2);

        Thread[] threads = new Thread[3]
        {
            new Thread(() => f.Logic()),
            new Thread(() => f.Logic()),
            new Thread(() => f.Logic())
        };

        foreach (Thread t in threads)
            t.Start();

        foreach (Thread t in threads)
            t.Join();
    }
}
