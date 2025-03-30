using System.Diagnostics;
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
using System.Windows.Threading;

namespace _02_TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer = null;
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 5);

            _timer.Tick += _timer_Tick;
            _timer.Start();

        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            Refresh(sender, null);
        }
        private void Refresh(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as RadioButton).Content.ToString());
            int choice = int.Parse((sender as RadioButton).Content.ToString());

            _timer.Stop();
            _timer.Interval = new TimeSpan(0, 0, choice);
            _timer.Start();
        }
        private void Kill(object sender, RoutedEventArgs e)
        {
            if ((grid.SelectedItem as Process) != null)
            {
                MessageBox.Show((grid.SelectedItem as Process).ProcessName);
                (grid.SelectedItem as Process).Kill();
            }
            else
                MessageBox.Show("Процес для видалення не був вибраний");
        }
        private void Go(object sender, RoutedEventArgs e)
        {
            string tmp = Info.Text.ToString();
            if (string.IsNullOrEmpty(tmp))
                MessageBox.Show("Поле для ведення пусте!");
            else
                Process.Start(tmp);
        }
        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            Process process = (grid.SelectedItem as Process);
            if (process != null)
            {
                MessageBox.Show
                    (
                    $"Id :: {process.Id}" +
                    $"\nProcess Name :: {process.ProcessName}" +
                    $"\nPriority :: {process.PriorityClass}" +
                    $"\nTotal Processor Time :: {process.TotalProcessorTime}" +
                    $"\nUser Processor Time :: {process.UserProcessorTime}" +
                    $"\nStart Time :: {process.StartTime}" +
                    $"\nFile path :: {process.MainModule.FileName}" +
                    $"\nCount Thread :: {process.Threads.Count}"
                    );
            }
            else
                MessageBox.Show("Процес для пергляду детальної інформіції не було вибрано");
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}