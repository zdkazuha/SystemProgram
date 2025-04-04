using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Security.AccessControl;
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

namespace _10_FileCopy_app
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            srcTextBox.Text = Source = @"C:\Users\SystemX\Downloads\1GB.bin";
            destTextBox.Text = Destination = @"C:\Users\SystemX\Desktop\TextCopy";
        }

        private void OpenFileBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                srcTextBox.Text = Source = dialog.FileName;
            }
        }
        private void OpenFolderBtn(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                destTextBox.Text = Destination = dialog.FileName;
            }
        }
        private async void CopyFileBtn(object sender, RoutedEventArgs e)
        {
            string FileName = System.IO.Path.Combine(Destination, System.IO.Path.GetFileName(Source));
            //File.Copy(Source, FileName);

            await CopyFileAsync(Source, FileName);
            MessageBox.Show("Complate");
        }

        private Task CopyFileAsync(string source,string dest)
        {
            return Task.Run(() =>
            {
                using (FileStream srcFile = new FileStream(source, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024 * 8]; // 8kb
                        int bytes = 0;
                        do
                        {
                            bytes = srcFile.Read(buffer, 0, buffer.Length);
                            destFile.Write(buffer, 0, bytes);
                            float percent = destFile.Length / (srcFile.Length / 100);
                            Dispatcher.Invoke(() => 
                            { 
                                progress.Value = percent;
                                percentage.Text = $"{percent}%";
                            });
                        }
                        while (bytes > 0);
                    }

                }
            });
        }
    }
}