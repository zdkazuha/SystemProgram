using System.ComponentModel.DataAnnotations;

internal class Program
{
    static int max, min;
    static double avg;

    static void Max(int[] aaray)
    {
        max = aaray.Max();
    }
    static void Min(int[] aaray)
    {
        min = aaray.Min(); 
    }
    static void Avg(int[] aaray)
    {
        avg = aaray.Average();
    }
    static void Text()
    {
        StreamWriter streamWriter = new StreamWriter("Text.txt");
        streamWriter.WriteLine($"Мінімальне число     :: {min}");
        streamWriter.WriteLine($"Максимальне число    :: {max}");
        streamWriter.WriteLine($"Середнеє арифметичне :: {avg}");
        streamWriter.Close();
    }
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Random random = new Random();

        int[] arr = new int[10000];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(1, 10001);
        }

        Thread threadMax = new Thread(() => Max(arr));
        Thread threadMin = new Thread(() => Min(arr));
        Thread threadAvg = new Thread(() => Avg(arr));

        threadMin.Start();
        threadAvg.Start();
        threadMax.Start();

        threadMin.Join();
        threadMax.Join();
        threadAvg.Join();

        Thread threadText = new Thread(Text);
        threadText.Start();
        threadText.Join();

        Console.WriteLine($"Мінімальне число     :: {min}");
        Console.WriteLine($"Максимальне число    :: {max}");
        Console.WriteLine($"Середнеє арифметичне :: {avg}");
    }
}