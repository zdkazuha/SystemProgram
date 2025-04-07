using Db_Library;
using Db_Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

namespace _06_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        static Library library = new Library();

        public MainWindow()
        {
            InitializeComponent();
            LoadAsync();
            ComboBoxAuthor.SelectionChanged += LoadBooks;
        }

        public async Task LoadAsync()
        {
            var authors = await library.Author.ToListAsync();  
            foreach (var item in authors)
            {
                ComboBoxAuthor.Items.Add(item);
            }
        }
        public async void LoadBooks(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxAuthor.SelectedIndex != -1)
            {
                ListBooks.Items.Clear();
                var item = (Author)ComboBoxAuthor.SelectedItem;

                var books = await LoadBooksAsync(item.Id);
                foreach (var book in books)
                    ListBooks.Items.Add(book);
            }
        }
        public async Task<List<Book>> LoadBooksAsync(int AuthorId)
        {
            return await library.Book
                .Where(b => b.AuthorId == AuthorId)
                .ToListAsync();
        }
        public async Task<List<Book>> LoadBooksTitleAsync()
        {
            string text = BookTitle.Text;
            if(text.Length < 3)
            {
                return new List<Book>();
            }

            var books = await library.Book
                .Where(book => book.Title.Contains(text))
                .ToListAsync();

            return books;
        }
        private async void BookTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var books = await LoadBooksTitleAsync();
            ListBooks.Items.Clear();
            foreach (var book in books)
            {
                ListBooks.Items.Add(book);
            }
        }
    }
}