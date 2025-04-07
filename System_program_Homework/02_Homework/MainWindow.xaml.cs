using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _02_Homework
{
    public partial class MainWindow : Window
    {
        Thread thread1 = null;
        Thread thread2 = null;
        bool Stop = false;
        bool Stopf = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int lowerBound = 2;
            int upperBound = int.MaxValue;

            if(int.TryParse(LowerBoundTextBox.Text, out int lower) && !string.IsNullOrEmpty(LowerBoundTextBox.Text))
            {
                if (lower < 2) 
                    lowerBound = 2;
                lowerBound = lower;
            }

            if (int.TryParse(UpperBoundTextBox.Text, out int upper) && !string.IsNullOrEmpty(LowerBoundTextBox.Text))
            {
                upperBound = upper;
            }

            PrimeNumbersListBox.Items.Clear();
            FibonachiNumbersListBox.Items.Clear();
            Stop = false;
            Stopf = false;
            GeneratePrimes(lowerBound, upperBound);
            GenerateFibonachi();
        }
        private bool IsPrime(int number)
        {
            if(number < 2 || number % 2 == 0) return false;
            if(number == 2) return true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        private void GeneratePrimes(int lowerBound, int upperBound)
        {
            thread1 = new Thread(() =>
            {
                Dispatcher.Invoke(() => PrimeNumbersListBox.Items.Add(2));
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    if (Stop == true)
                        return;

                    if (IsPrime(i))
                    {
                        Dispatcher.Invoke(() => PrimeNumbersListBox.Items.Add(i));
                        Thread.Sleep(100);
                    }
                }
            });
            thread1.Start();
        }
        private void GenerateFibonachi()
        {
            int number1 = 1;
            int number2 = 2;
            int number3 = 0;

            Dispatcher.Invoke(() => FibonachiNumbersListBox.Items.Add(number1));
            Dispatcher.Invoke(() => FibonachiNumbersListBox.Items.Add(number2));

            thread2 = new Thread(() =>
            {
                while (true) 
                {
                    if (Stopf == true)
                        return;

                    number3 = number1 + number2;
                    number1 = number2;
                    number2 = number3;
                    Dispatcher.Invoke(() => FibonachiNumbersListBox.Items.Add(number3));
                    Thread.Sleep(100);
                }
            });
            thread2.Start();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Stop = true;
            Stopf = true;
            if (thread1 != null)
            {
                thread1.Join(); 
            }
        }
        private void StopButtonF_Click(object sender, RoutedEventArgs e)
        {
            Stopf = true;
            if (thread2 != null)
            {
                thread2.Join();
            }
        }
    }
}