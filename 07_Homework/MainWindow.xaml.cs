using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace _07_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string folderPath = "Resumes";
        static List<Resume> Resumes;
        static int ID = 0;
        public MainWindow()
        {
            InitializeComponent();
            Resumes = new List<Resume>();
            FillResumeAsync();
            FillCity();

            ComboBoxSort.SelectionChanged += Sorts;
            ComboBoxCity.SelectionChanged += CandidatesFromCity;
        }

        public async void FillResumeAsync()
        {
            List<Resume> resumes = new List<Resume>
        {
            new Resume { FirstName = "Ivan", SurName = "Shevchenko", PhoneNumber = "+380501234567", City = "Kyiv", YearsOfExperience = 5, Salary = 25000 },
            new Resume { FirstName = "Olena", SurName = "Koval", PhoneNumber = "+380631112233", City = "Lviv", YearsOfExperience = 3, Salary = 20000 },
            new Resume { FirstName = "Andrii", SurName = "Bondarenko", PhoneNumber = "+380671234567", City = "Odesa", YearsOfExperience = 7, Salary = 30000 },
            new Resume { FirstName = "Nadiya", SurName = "Tkachenko", PhoneNumber = "+380931234567", City = "Kharkiv", YearsOfExperience = 2, Salary = 18000 },
            new Resume { FirstName = "Taras", SurName = "Melnyk", PhoneNumber = "+380991234567", City = "Dnipro", YearsOfExperience = 10, Salary = 40000 },
            new Resume { FirstName = "Kateryna", SurName = "Kravchenko", PhoneNumber = "+380661234567", City = "Zaporizhzhia", YearsOfExperience = 4, Salary = 22000 },
            new Resume { FirstName = "Oksana", SurName = "Boyko", PhoneNumber = "+380681234567", City = "Vinnytsia", YearsOfExperience = 6, Salary = 27000 },
            new Resume { FirstName = "Mykola", SurName = "Polishchuk", PhoneNumber = "+380951234567", City = "Ternopil", YearsOfExperience = 1, Salary = 15000 },
            new Resume { FirstName = "Yulia", SurName = "Zaytseva", PhoneNumber = "+380631234678", City = "Kyiv", YearsOfExperience = 9, Salary = 35000 },
            new Resume { FirstName = "Serhii", SurName = "Ivanov", PhoneNumber = "+380501111111", City = "Lviv", YearsOfExperience = 8, Salary = 33000 },

            new Resume { FirstName = "Iryna", SurName = "Petrenko", PhoneNumber = "+380992222222", City = "Odesa", YearsOfExperience = 3, Salary = 21000 },
            new Resume { FirstName = "Dmytro", SurName = "Levchenko", PhoneNumber = "+380981234567", City = "Kharkiv", YearsOfExperience = 5, Salary = 26000 },
            new Resume { FirstName = "Svitlana", SurName = "Mazur", PhoneNumber = "+380673334455", City = "Dnipro", YearsOfExperience = 12, Salary = 50000 },
            new Resume { FirstName = "Vasyl", SurName = "Kushnir", PhoneNumber = "+380633334455", City = "Lutsk", YearsOfExperience = 7, Salary = 31000 },
            new Resume { FirstName = "Halyna", SurName = "Pavlenko", PhoneNumber = "+380661122334", City = "Chernihiv", YearsOfExperience = 2, Salary = 17000 },
            new Resume { FirstName = "Yevhen", SurName = "Moroz", PhoneNumber = "+380681122334", City = "Poltava", YearsOfExperience = 6, Salary = 28000 },
            new Resume { FirstName = "Lesya", SurName = "Vorona", PhoneNumber = "+380951122334", City = "Uzhhorod", YearsOfExperience = 4, Salary = 23000 },
            new Resume { FirstName = "Roman", SurName = "Nesterenko", PhoneNumber = "+380671122334", City = "Rivne", YearsOfExperience = 8, Salary = 34000 },
            new Resume { FirstName = "Marta", SurName = "Lytvyn", PhoneNumber = "+380931122334", City = "Ivano-Frankivsk", YearsOfExperience = 10, Salary = 42000 },
            new Resume { FirstName = "Artem", SurName = "Hlushko", PhoneNumber = "+380991122334", City = "Cherkasy", YearsOfExperience = 3, Salary = 19000 },

            new Resume { FirstName = "Lilia", SurName = "Danylko", PhoneNumber = "+380661111222", City = "Zhytomyr", YearsOfExperience = 5, Salary = 25000 },
            new Resume { FirstName = "Oleh", SurName = "Kryvyi", PhoneNumber = "+380671111222", City = "Sumy", YearsOfExperience = 1, Salary = 14000 },
            new Resume { FirstName = "Natalia", SurName = "Shapoval", PhoneNumber = "+380681111222", City = "Mykolaiv", YearsOfExperience = 7, Salary = 32000 },
            new Resume { FirstName = "Bohdan", SurName = "Prokopchuk", PhoneNumber = "+380691111222", City = "Kherson", YearsOfExperience = 6, Salary = 29000 },
            new Resume { FirstName = "Yana", SurName = "Kozak", PhoneNumber = "+380501113355", City = "Chernivtsi", YearsOfExperience = 4, Salary = 22000 },
            new Resume { FirstName = "Oleksandr", SurName = "Dubovyk", PhoneNumber = "+380991113355", City = "Kropyvnytskyi", YearsOfExperience = 2, Salary = 16000 },
            new Resume { FirstName = "Valeria", SurName = "Zadorozhna", PhoneNumber = "+380981113355", City = "Mukachevo", YearsOfExperience = 11, Salary = 45000 },
            new Resume { FirstName = "Denys", SurName = "Chernov", PhoneNumber = "+380661113355", City = "Bila Tserkva", YearsOfExperience = 9, Salary = 37000 },
            new Resume { FirstName = "Anastasia", SurName = "Korol", PhoneNumber = "+380931113355", City = "Brody", YearsOfExperience = 5, Salary = 26000 },
            new Resume { FirstName = "Pavlo", SurName = "Hrytsenko", PhoneNumber = "+380991122111", City = "Fastiv", YearsOfExperience = 8, Salary = 34000 }
        };

            string folderPath = "Resumes";
            Directory.CreateDirectory(folderPath);

            foreach (var resume in resumes)
            {
                string fileName = $"Resume_{resume.FirstName}_{resume.SurName}.txt";
                string filePath = Path.Combine(folderPath, fileName);
                await File.WriteAllTextAsync(filePath, resume.ToFile());
            }
        }

        public void Sorts(object sender, SelectionChangedEventArgs e)
        {
            if(!Checking())
                return;
            FillCity();
            if (ComboBoxSort.SelectedIndex != -1)
            {
                switch (ComboBoxSort.SelectedIndex)
                {
                    case 0:
                        TheMostExperiencedCandidate();
                        break;
                    case 1:
                        TheMostInexperiencedCandidate();
                        break;
                    case 2:
                        CandidatesFromOneCity();
                        break;
                    case 3:
                        CandidatesFromCity(sender, e);
                        break;
                    case 4:
                        CandidateWithTheLowestSalaryRequirement();
                        break;
                    case 5:
                        CandidateWithTheHighestSalaryRequirements();
                        break;
                }
            }
        }

        public void TheMostExperiencedCandidate()
        {
            int max = Resumes.Max(r => r.YearsOfExperience);

            var sortedResumes = Resumes
                .Where(r => r.YearsOfExperience == max)
                .ToList();

            FillListBox(sortedResumes);
        }
        public void TheMostInexperiencedCandidate()
        {
            int min = Resumes.Min(r => r.YearsOfExperience);

            var sortedResumes = Resumes
                .Where(r => r.YearsOfExperience == min)
                .ToList();

            FillListBox(sortedResumes);
        }
        private void FillListBox(List<Resume> sortedResumes)
        {
            ListResume.Items.Clear();
            foreach (var resume in sortedResumes)
            {
                ListResume.Items.Add(resume);
            }
        }

        public void FillCity()
        {
            ComboBoxCity.Items.Clear();

            foreach (var city in Resumes.Select(r => r.City).Distinct())
            {
                ComboBoxCity.Items.Add(city);
            }
        }
        public void CandidatesFromOneCity()
        {
            var SortedCity = Resumes
                .OrderBy(r => r.City)
                .ToList();

            FillListBox(SortedCity);
        }
        public void CandidatesFromCity(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSort.SelectedIndex != 3)
                return;

            var City = ComboBoxCity.SelectedItem;

            if (City == null)
                return;

            var sortedResumes = Resumes
                .Where(r => r.City == City)
                .ToList();

            FillListBox(sortedResumes);
        }

        public void CandidateWithTheLowestSalaryRequirement()
        {
            int min = Resumes.Min(r => r.Salary);

            var sortedResumes = Resumes
                .Where(r => r.Salary == min)
                .ToList();

            FillListBox(sortedResumes);
        }
        public void CandidateWithTheHighestSalaryRequirements()
        {
            int max = Resumes.Max(r => r.Salary);

            var sortedResumes = Resumes
                .Where(r => r.Salary == max)
                .ToList();

            FillListBox(sortedResumes);
        }

        private bool Checking()
        {
            if (Resumes.Count == 0)
            {
                MessageBox.Show("Ви не завантажили жодного резюме");
                return false;
            }
            return true;
        }
        private bool CheckingFile()
        {
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Папку {folderPath} не було знайдено: \n" +
                                $"Викличте FillResumeAsync(); в MainWindow");
                return false;
            }
            var File = Directory.GetFiles(folderPath);
            if (Resumes.Count == File.Length)
            {
                MessageBox.Show("Всі вже резюме були завантажені");
                return false;
            }
            return true;

        }
        public async void DownloadOneResume(object sender, RoutedEventArgs e)
        {
            if(ID == 0)
            {
                if (!CheckingFile())
                    return;
            }
            var File = Directory.GetFiles(folderPath);
            if (ID >= File.Length)
            {
                MessageBox.Show("Резюме закінчились");
                return;
            }
            var fileName = File[ID];
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    Resumes.Add(new Resume
                    {
                        FirstName = line,
                        SurName = sr.ReadLine(),
                        PhoneNumber = sr.ReadLine(),
                        City = sr.ReadLine(),
                        YearsOfExperience = int.Parse(sr.ReadLine()),
                        Salary = int.Parse(sr.ReadLine())
                    });
                }
            }
            
            ID++;
            MessageBox.Show($"Резюме було успішно завантажено");
            Sorts(null, null);
            FillCity();
        }
        public async void DownloadAllResume(object sender, RoutedEventArgs e)
        {
            if (ID == 0)
            {
                if (!CheckingFile())
                    return;
            }
            var File = Directory.GetFiles(folderPath);
            int tmp = 0;
            if (ID >= File.Length)
            {
                MessageBox.Show("Резюме закінчились");
                return;
            }
            for (int i = ID; i < File.Length; i++)
            {
                tmp++;
                var fileName = File[i];
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        Resumes.Add(new Resume
                        {
                            FirstName = line,
                            SurName = sr.ReadLine(),
                            PhoneNumber = sr.ReadLine(),
                            City = sr.ReadLine(),
                            YearsOfExperience = int.Parse(sr.ReadLine()),
                            Salary = int.Parse(sr.ReadLine())
                        });
                    }
                    ID = i + 1;
                }
            }
            MessageBox.Show($"Всі резюме якій залишились було успішно завантажено: {tmp}");
            Sorts(null, null);
            FillCity();
        }
        public void DownloadCountResume(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DownloadCountResume_(sender, e);
            }
        }
        private async void DownloadCountResume_(object sender, RoutedEventArgs e)
        {
            if (ID == 0)
            {
                if (!CheckingFile())
                    return;
            }
            var File = Directory.GetFiles(folderPath);
            if (ID >= File.Length)
            {
                MessageBox.Show("Резюме закінчились");
                return;
            }
            int tmp = int.Parse(CountResume.Text);
            int Count = ID + tmp;
            if (Count >= File.Length)
            {
                MessageBox.Show($"Ви хочете завантажити забагато файлів: іх залишилось {(File.Length - ID)}");
                return;
            }
            for (int i = ID; i < Count; i++)
            {
                var fileName = File[i];
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        Resumes.Add(new Resume
                        {
                            FirstName = line,
                            SurName = sr.ReadLine(),
                            PhoneNumber = sr.ReadLine(),
                            City = sr.ReadLine(),
                            YearsOfExperience = int.Parse(sr.ReadLine()),
                            Salary = int.Parse(sr.ReadLine())
                        });
                    }
                    ID = i + 1;
                }
            }
            MessageBox.Show($"{tmp} резюме було успішно завантажено");
            Sorts(null, null);
            FillCity();
        }
    }

    public class Resume
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public int YearsOfExperience { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return
            $@"{FirstName}
            Прізвище: {SurName}
            Телефон: {PhoneNumber}
            Місто: {City}
            Досвід роботи: {YearsOfExperience} років
            Бажана зарплата: {Salary} грн";
        }

        public string ToFile()
        {
            return
            $@"{FirstName}
{SurName}
{PhoneNumber}
{City}
{YearsOfExperience}
{Salary}";
        }
    }

}