using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WpfApp_Framework.Models;
using WpfApp_Framework.ViewModels;

namespace WpfApp_Framework
{
    public partial class MainWindow : Window
    {
        static readonly string apiUrl = ConfigurationManager.AppSettings["RestApiBaseUrl"];
        static HttpClient _httpClient = new HttpClient();

        public ObservableCollection<Dolgozo> Dolgozok { get; }
        = new ObservableCollection<Dolgozo>();

        public Dolgozo SelectedDolgozo { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await GetAllFromBackend();
        }

        async Task GetAllFromBackend()
        {
            var json = await _httpClient.GetStringAsync(apiUrl);
            var lista = Dolgozo.FromJson(json);

            Dolgozok.Clear();
            foreach (var d in lista)
            {
                d.ImageUrl = $"https://randomuser.me/api/portraits/men/{d.Id % 100}.jpg";
                Dolgozok.Add(d);
            }
        }

    }
}
