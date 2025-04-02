using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _08_Generate_Asunsc_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ViewNumber(object sender, RoutedEventArgs e)
        {
            //Task<int> task = Task.Run(GenerateValue);
            //await task;
            //int value = task.Result; // Wait
            list.Items.Add(await GenerateValueAsync());
                        
            //Student st = new Student() { Name = "Denis", SurName = "Bondar" };
            //list.Items.Add(st);
        }

        int GenerateValue()
        {
            Thread.Sleep(random.Next(5000));
            return random.Next(1000);
        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(random.Next(5000));
                return random.Next(1000);
            });
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public override string ToString()
        {
            return $"{Name} {SurName}";
        }
    }
}