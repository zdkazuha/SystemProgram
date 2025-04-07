
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

namespace _05_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberFactorial.Text, out int number))
            {
                ListFactorial.Items.Add(await Factorial(number));
            }
            else
            {
                MessageBox.Show("Число не введене або некоректне");
            }
        }


        Task<int> Factorial(int number)
        {
            return Task.Run(() =>
            {
                if(number < 0)
                    // Якщо число менше 0, повертаємо -1 тому що факторіал від'ємного числа не існує
                    return -1;

                int result = 1;
                for (int i = 2; i <= number; i++)
                    result *= i;

                Thread.Sleep(1000);
                return result;
            });
        }
    }
}