using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Task 1 and 2

        //int factorialResult = 1, CounterResult = 0,SumResult = 0;

        //Console.WriteLine("Введіть число факторіал якго хочете обчислити :: ");
        //int number = int.Parse(Console.ReadLine()!);
        //Parallel.Invoke(() => factorialResult = Factorial(number));

        //Parallel.Invoke(
        //    () => Counter(factorialResult),
        //    () => SumCounter(factorialResult)
        //     );

        // Task 3

        //Console.WriteLine("Введіть першу межу :: ");
        //int number1 = int.Parse(Console.ReadLine()!);

        //Console.WriteLine("Введіть другу межу :: ");
        //int number2 = int.Parse(Console.ReadLine()!);
        //if (number1 > number2)
        //{
        //    int temp = number1;
        //    number1 = number2;
        //    number2 = temp;
        //}
        //Parallel.For(number1, number2+1, MultiplicationTable);

        //Task 4

        //string fileName = @"../../../file.txt";
        //List<int> ints1 = new List<int>();
        //using (StreamReader sr = new StreamReader(fileName))
        //{
        //    while (true)
        //    {
        //        string line = sr.ReadLine();
        //        if (line == null)
        //            break;
        //        if (int.TryParse(line, out int number))
        //            ints1.Add(number);
        //    }
        //}

        //List<int> ints2 = new List<int>();
        //Parallel.ForEach(ints1, number =>
        //{
        //    int result = Factorialx(number);
        //    ints2.Add(result);
        //});
        //ints1.Sort();
        //ints2.Sort();
        //for (int i = 0; i < ints1.Count; i++)
        //{
        //    Console.WriteLine($"Факторіал числа {ints1[i]} == {ints2[i]}");
        //}

        //Task 5

        //string fileName2 = @"../../../file.txt";
        //List<int> ints3 = new List<int>();
        //using (StreamReader sr2 = new StreamReader(fileName2))
        //{
        //    while (true)
        //    {
        //        string line2 = sr2.ReadLine();
        //        if (line2 == null)
        //            break;
        //        if (int.TryParse(line2, out int number))
        //            ints3.Add(number);
        //    }
        //}

        //var pn = ints3.AsParallel().ToList();

        //SumTask(pn);
        //MaxTask(pn);
        //MinTask(pn);
    }

    static void SumTask(List<int> list)
    {
        int sum = list.AsParallel().Sum();  
        Console.WriteLine($"Сума: {sum}");
    }
    static void MaxTask(List<int> list)
    {
        int max = list.AsParallel().Max();
        Console.WriteLine($"Максимум: {max}");
    }
    static void MinTask(List<int> list)
    {
        int min = list.AsParallel().Min();
        Console.WriteLine($"Мінімум: {min}");
    }
    static void MultiplicationTable(int number)
    {
        lock (Console.Out)  
        {
            Console.WriteLine($"\nТаблиця множення числа {number}:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} * {i} = {number * i}");
            }
            Console.WriteLine();  
        }
    }
    static void Counter(int x)
    {
        int count = 0, number = x;
        do
        {
            count++;
            number /= 10;
        } while (number != 0);
        Console.WriteLine($"Кількість цифр в числі {x} == {count}");
    }
    static void SumCounter(int x)
    {
        int sum = 0, number = x;
        do
        {
            sum += number % 10;
            number /= 10;
        } while (number != 0);
        Console.WriteLine($"Сума цифр в числі {x} = {sum}");
    }
    static int Factorial(int number)
    {
        int result = 1;
        for (int i = 1; i <= number; i++)
            result *= i;

        Console.WriteLine($"Факторіал числа {number} = {result}");
        return result;
    }
    static int Factorialx(int number)
    {
        int result = 1;
        for (int i = 1; i <= number; i++)
            result *= i;

        return result;
    }
}
