internal class Program
{
    private static void Main(string[] args)
    {

        int item1 = int.Parse(args[0]);
        int item2 = int.Parse(args[1]);
        string item3 = args[2];

        switch (item3)
        {
            case "+":
                Console.WriteLine($"{item1} + {item2}");
                Console.WriteLine($"Result {item1 + item2}");
                break;
            case "-":
                Console.WriteLine($"{item1} - {item2}");
                Console.WriteLine($"Result {item1 - item2}");
                break;
            case "*":
                Console.WriteLine($"{item1} * {item2}");
                Console.WriteLine($"Result {item1 * item2}");
                break;
            case "/":
                Console.WriteLine($"{item1} / {item2}");
                Console.WriteLine($"Result {item1 / item2}");
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;

        }
    }
}