using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmoothProgressBarDemo
{
    [AddINotifyPropertyChangedInterface]
    public partial class MainWindow : Window
    {
        public ObservableCollection<FileSearchInfo> Files { get; set; } = new ObservableCollection<FileSearchInfo>();
        public double TotalProgress { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                FolderBox.Text = dialog.FileName;
        }

        private async void StartSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WordBox.Text) || string.IsNullOrWhiteSpace(FolderBox.Text))
            {
                MessageBox.Show("Будь ласка, введіть слово та виберіть папку.");
                return;
            }

            Files.Clear();
            TotalProgress = 0;

            string word = WordBox.Text;
            var filePaths = Directory.GetFiles(FolderBox.Text, "*.txt*", SearchOption.AllDirectories);


            foreach (var path in filePaths)
            {
                Files.Add(new FileSearchInfo
                {
                    FileName = Path.GetFileName(path),
                    FilePath = path
                });
            }

            List<Task> tasks = new List<Task>();

            foreach (var f in Files)
                tasks.Add(ProcessFile(f, word));

            await Task.WhenAll(tasks);

            SaveResults();
        }

        private async Task ProcessFile(FileSearchInfo file, string word)
        {
            var fileInfo = new FileInfo(file.FilePath);
            long fileSize = fileInfo.Length;
            long totalRead = 0;
            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            int wordCount = 0;

            try
            {
                using (var stream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead;
                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        string textChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        string[] words = textChunk.Split(new[] { ' ', '\r', '\n', '\t', '.', ',', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries);

                        wordCount += words.Count(w => string.Equals(w, word, StringComparison.OrdinalIgnoreCase));

                        totalRead += bytesRead;
                        double percent = (double)totalRead / fileSize * 100;

                        await Dispatcher.InvokeAsync(() =>
                        {
                            file.Progress = Math.Round(percent, 1);
                            file.WordCount = wordCount;
                            UpdateTotalProgress();
                        });

                        await Task.Delay(100);
                    }
                }

                await Dispatcher.InvokeAsync(() =>
                {
                    file.Progress = 100;
                    file.WordCount = wordCount;
                    UpdateTotalProgress();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing file {file.FileName}: {ex.Message}");
                return;
            }
        }


        private void UpdateTotalProgress()
        {
                TotalProgress = Math.Round(Files.Average(f => f.Progress), 1);
        }

        private void SaveResults()
        {
            string resultFile = "../../../results.txt";
            var lines = Files.Select(f =>
                $"Файл: {f.FileName}\nШлях: {f.FilePath}\nКількість знайдених слів: {f.WordCount}\n");
            File.WriteAllLines(resultFile, lines);
            MessageBox.Show($"Результати збережено в файл");
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class FileSearchInfo
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int WordCount { get; set; }
        public double Progress { get; set; }
    }
}
