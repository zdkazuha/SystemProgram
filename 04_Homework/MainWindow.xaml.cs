using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _04_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class InfoText_
        {
            public InfoText_(string text)
            {
                Text = text;
            }
            public string Text;
            public int Line = 0;
            public int Symbol = 0;
            public int World = 0;
            public int Question = 0;
            public int Exclamatory = 0;

            public void Check()
            {
                Task[] tasks = new Task[5]
                {
                    Task.Run(() =>
                    {
                        foreach (char c in Text)
                            if (c == '\n')
                                Line++;
                    }),
                    Task.Run(() =>
                    {
                        foreach (char c in Text)
                            if (c != '\n' && c != ' ' && c != '\t')
                                Symbol++;
                    }),
                    Task.Run(() =>
                    {
                        bool InWorlds = false;
                        foreach (char c in Text)
                        {
                            if (c != ' ' && c != '\n')
                            {
                                if (!InWorlds)
                                {
                                    InWorlds = true;
                                    World++;
                                }
                            }
                            else
                                InWorlds = false;
                        }
                    }),
                    Task.Run(() =>
                    {
                        char[] chars = Text.ToCharArray();
                        for (int i = 0; i < chars.Length - 1; i++)
                        {
                            if (chars[i] == '?' && chars[i+1] == '\n')
                                Question++;
                        }
                    }),
                    Task.Run(() =>
                    {
                        char[] chars = Text.ToCharArray();
                        for (int i = 0; i < chars.Length -1; i++)
                        {
                            if (chars[i] == '!' && chars[i+1] == '\n')
                                Exclamatory++;
                        }
                    })
                };

                Task.WaitAll(tasks);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            InfoText.Items.Clear();

            if (string.IsNullOrEmpty(TextLine.Text))
            {
                MessageBox.Show("Поле для записку реченнь пусте!!!");
                return;
            }
            else
                CheckText();
        }

        private void SaveInfoToFile(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextLine.Text))
            {
                MessageBox.Show("Поле для записку реченнь пусте!!!");
                return;
            }
            else
                SaveInfo();
        }

        private void CheckText()
        {
            InfoText_ it = new InfoText_(TextLine.Text);
            it.Check();

            InfoText.Items.Add($"Кількість речень :: {it.Line}");
            InfoText.Items.Add($"Кількість символів :: {it.Symbol}");
            InfoText.Items.Add($"Кількість слів :: {it.World}");
            InfoText.Items.Add($"Кількість питальних речень :: {it.Question}");
            InfoText.Items.Add($"Кількість окличних речень :: {it.Exclamatory}");
        }

        private void SaveInfo()
        {
            InfoText_ it = new InfoText_(TextLine.Text);
            it.Check();

            string path = "../../../Text.exe";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine($"Кількість речень :: {it.Line}");
                sw.WriteLine($"Кількість символів :: {it.Symbol}");
                sw.WriteLine($"Кількість слів :: {it.World}");
                sw.WriteLine($"Кількість питальних речень :: {it.Question}");
                sw.WriteLine($"Кількість окличних речень :: {it.Exclamatory}");
            }
        }

    }
}