using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Task 1

        //string fileName1 = @"../../../file1.txt";
        //List<int> ints1 = new List<int>();
        //using (StreamReader File1 = new StreamReader(fileName1))
        //{
        //    while (true)
        //    {
        //        string line = File1.ReadLine();
        //        if (line == null)
        //            break;

        //        if (int.TryParse(line, out int number))
        //            ints1.Add(number);
        //    }
        //}

        //var sort = ints1.AsParallel()
        //    .Distinct()
        //    .ToList();

        //for (int i = 0; i < sort.Count; i++)
        //    Console.WriteLine($"№{i + 1} - {sort[i]}");

        //Console.WriteLine($"\nСума унікальних значень у файлі == {sort.Count()}");


        // Task 2

        //string fileName2 = @"../../../file2.txt";
        //List<int> ints2 = new List<int>();
        //using (StreamReader File2 = new StreamReader(fileName2))
        //{
        //    while (true)
        //    {
        //        string line = File2.ReadLine();
        //        if (line == null)
        //            break;
        //        if (int.TryParse(line, out int number))
        //            ints2.Add(number);
        //    }
        //}
        //List<int> tmp = new List<int>();
        //List<int> Max = new List<int>();

        //tmp.Add(ints2[0]);

        //for (int i = 1; i < ints2.Count; i++)
        //{
        //    if (ints2[i] > ints2[i - 1])
        //        tmp.Add(ints2[i]);

        //    else
        //    {
        //        if (tmp.Count > Max.Count)
        //            Max = new List<int>(tmp);

        //        tmp.Clear();
        //        tmp.Add(ints2[i]);
        //    }
        //}
        //if (tmp.Count > Max.Count)
        //    Max = new List<int>(tmp);

        //Console.WriteLine(String.Join(", ",Max));
    }
}