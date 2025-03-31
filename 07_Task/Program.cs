using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Taks 1

        //Task task1 = new Task(() => Console.WriteLine($"Time :: {DateTime.Now.TimeOfDay} Date :: {DateTime.Now.Date}"));
        //task1.Start();

        //Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Time :: {DateTime.Now.TimeOfDay} Date :: {DateTime.Now.Date}"));

        //Task task3 = Task.Run(() => Console.WriteLine($"Time :: {DateTime.Now.TimeOfDay} Date :: {DateTime.Now.Date}"));   

        //task1.Wait();
        //task2.Wait();
        //task3.Wait();

        //Console.WriteLine("Main ending working...");

        // Task 2 and 3

        //Console.Write("Введіть нижнью межу  :: ");
        //int low = int.Parse(Console.ReadLine());
        //Console.Write("Введіть верхнью межу :: ");
        //int up = int.Parse(Console.ReadLine());

        //Task<int> task1 = new Task<int>(() => PrimeNumbers(low,up));
        //task1.Start();

        //var res = task1.Result;
        //Console.WriteLine($"\nКількість простих чисел :: {res}\n");

        //Console.WriteLine("Main ending working...");

        // Task 4 

        //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        //Task<int>[] tasks1 = new Task<int>[4]
        //{
        //                new Task<int>(() => arr.Min()),
        //                new Task<int>(() => arr.Max()),
        //                new Task<int>(() => (int)arr.Average()),
        //                new Task<int>(() => arr.Sum())
        //};
        //foreach (var t in tasks1)
        //    t.Start();

        //Console.WriteLine($"Min     :: {tasks1[0].Result}");
        //Console.WriteLine($"Max     :: {tasks1[1].Result}");
        //Console.WriteLine($"Average :: {tasks1[2].Result}");
        //Console.WriteLine($"Sum     :: {tasks1[3].Result}");

        //Console.WriteLine("\nMain ending working...");

        // Task 5

        //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 1, 8, 3, 7, 3, 6, 7, 0, 3 };

        //Task<int[]> task1 = Task.Run(() =>
        //{
        //    return DeleteDublicate(arr);
        //});

        //Task<int[]> task2 = task1.ContinueWith(previousTask =>
        //{
        //    int[] Arr = previousTask.Result;
        //    Array.Sort(Arr);
        //    return Arr;
        //});

        //Task<int> task3 = task2.ContinueWith(previousTask =>
        //{
        //    int[] Arr = previousTask.Result;
        //    var res = Array.BinarySearch(arr, 1);
        //    return res;
        //});

        //Task task4 = task3.ContinueWith(previousTask =>
        //{
        //    var res = previousTask.Result;
        //    Console.WriteLine($"індекс значення 1 :: {res}");
        //});
        //task4.Wait();

        //Console.WriteLine("\nMain ending working...");
    }
    static public bool IsPrime(int x)
    {
        if (x < 2 || x % 2 == 0 || x == 0) return false;
        if (x == 2) return true;

        for (int i = 2; i < x; i++)
        {
            if (x % i == 0)
                return false;
        }
        return true;
    }
    static public int PrimeNumbers(int low, int up)
    {

        Console.WriteLine("Prime numbers :: \n");

        int counter = 0;
        for (int i = low; i < up; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
                counter++;
            }
        }
        return counter;
    }
    static public int[] DeleteDublicate(int[] arr)
    {
        return arr.Distinct().ToArray();
    }
}
