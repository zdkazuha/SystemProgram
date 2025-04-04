using System;
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
using Path = System.IO.Path;

namespace _09_Practical_work
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
        private async void CopyFile(object sender, RoutedEventArgs e)
        {
            try
            {
                CopyFile cf = new CopyFile(NameFile.Text, NameDirectory.Text, int.Parse(Number.Text));
                await cf.CopyAsync();
                MessageBox.Show("Копіювання завершено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CopyFile(sender, e);
        }

        private void OnKeyDownHandler2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CopyFile(sender, e);
        }
    }

    class CopyFile
    {
        public CopyFile(string nf, string nd, int copyCount)
        {
            FileName = nf;
            DirectoryName = nd;
            CopyCount = copyCount;
        }

        private string filePath = string.Empty;
        public string FileName { get; set; }
        public string DirectoryName { get; set; }
        public int CopyCount { get; set; } = 1;

        public async Task CopyAsync()
        {
            await Task.Run(async () =>
            {
                if (!File.Exists(FileName))
                    MessageBox.Show("Исходный файл не найден", FileName);

                if (!Directory.Exists(DirectoryName))
                    Directory.CreateDirectory(DirectoryName);

                for (int i = 1; i <= CopyCount; i++)
                {
                    filePath = Path.Combine(DirectoryName, $"{Path.GetFileName(FileName)}_copy{i}{Path.GetExtension(FileName)}");

                    try
                    {
                        using (FileStream sourceStream = new FileStream(FileName, FileMode.Open))
                        using (FileStream destinationStream = new FileStream(filePath, FileMode.Create))
                        {
                            Thread.Sleep(3000);
                            await sourceStream.CopyToAsync(destinationStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при копировании файла {FileName} в {filePath}: {ex.Message}");
                    }
                }
            });
        }
    }
}