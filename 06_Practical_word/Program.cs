using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    public class Stat
    {
        public int Words { get; set; }
        public int Lines { get; set; }
        public int Punctuation { get; set; }
    }

    static void Main()
    {
        Stat stat = new Stat();

        string[] files = Directory.GetFiles(@"../../../Files");

        List<Thread> threads = new List<Thread>();

        foreach (string file in files)
        {
            Thread thread = new Thread(() => AnalyzeFile(file, stat));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
            thread.Join();

        Console.WriteLine($"Общее количество слов: {stat.Words}");
        Console.WriteLine($"Общее количество строк: {stat.Lines}");
        Console.WriteLine($"Общее количество знаков препинания: {stat.Punctuation}");
    }

    private static void AnalyzeFile(string filePath, Stat stat)
    {
        int words = 0, lines = 0, punctuation = 0;

        foreach (var line in File.ReadLines(filePath))
        {
            lines++;

            bool inWord = false;
            foreach (var ch in line)
            {
                if (ch != ' ' && ch != '\n')
                {
                    if (!inWord)
                    {
                        inWord = true;
                        words++;
                    }
                }
                else
                    inWord = false;
            }

            foreach (var ch in line)
            {
                if (char.IsPunctuation(ch))
                    punctuation++;
            }
        }

        lock (stat)
        {
            stat.Words += words;
            stat.Lines += lines;
            stat.Punctuation += punctuation;
        }
    }
}
