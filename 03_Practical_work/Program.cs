using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        #region Task 1
        //Process pr = new Process();
        //pr.StartInfo.FileName = "notepad.exe";
        //pr.Start();

        //Console.WriteLine("Press key to do operation...");
        //Console.ReadKey();

        //pr.WaitForExit();
        //Console.WriteLine($"\nExist Code {pr.ExitCode}");
        //pr.Close();
        #endregion

        #region Task 2
        //while (true)
        //{
        //    Console.Clear();
        //    Console.WriteLine("\n\t1 :: відкрити paint\n\t2 :: відкрити notepad\n\t3 :: відкрити calc\n\t0 :: Вихід\n");

        //    Console.WriteLine("\nВведіть номер процесу якій хочете виконати");

        //    int choice = int.Parse(Console.ReadLine()!);
        //    Process pr = new Process();
        //    if(choice == 0)
        //    {
        //        return;
        //    }
        //    switch (choice)
        //    {
        //        case 1:
        //            pr.StartInfo.FileName = "mspaint.exe";
        //            pr.Start();

        //            pr.WaitForExit();
        //            Console.WriteLine($"\nExist Code {pr.ExitCode}");
        //            Console.ReadKey();

        //            pr.Close();
        //            break;
        //        case 2:
        //            pr.StartInfo.FileName = "notepad.exe";
        //            pr.Start();

        //            pr.WaitForExit();
        //            Console.WriteLine($"\nExist Code {pr.ExitCode}");
        //            Console.ReadKey();

        //            pr.Close();
        //            break;
        //        case 3:
        //            pr.StartInfo.FileName = "calc.exe";
        //            pr.Start();

        //            pr.WaitForExit();
        //            Console.WriteLine($"\nExist Code {pr.ExitCode}");
        //            Console.ReadKey();

        //            pr.Close();
        //            break;
        //        default:
        //            Console.WriteLine("Error");
        //            break;
        //    }
        //}

        #endregion

        #region Task 3

        Console.WriteLine("Введіть перше число :: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть друге число :: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть операцію ( +,-,*,/ ) :: ");
        string operation = Console.ReadLine();

        Process.Start(@"C:\Users\SystemX\source\repos\SystemProgram\00_GetArgument\bin\Debug\net9.0\00_GetArgument.exe", $"{num1} {num2} {operation}");

        Console.WriteLine("Press key to do operation...");
        Console.ReadKey();

        #endregion
    }
}