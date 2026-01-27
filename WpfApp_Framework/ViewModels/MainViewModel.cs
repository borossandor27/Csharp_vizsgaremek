using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using framework_WpfApp.Commands;
using framework_WpfApp.Models;
using framework_WpfApp.Services;

namespace framework_WpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDolgozoApiService _api;

        public ObservableCollection<Dolgozo> Dolgozok { get; }
            = new ObservableCollection<Dolgozo>();

        private Dolgozo _selectedDolgozo;
        public Dolgozo SelectedDolgozo
        {
            get { return _selectedDolgozo; }
            set { _selectedDolgozo = value; OnPropertyChanged(); }
        }

        public RelayCommand LoadCommand { get; }
        public RelayCommand InsertCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public MainViewModel()
        {
            _api = new DolgozoApiService();

            LoadCommand = new RelayCommand(async () => await LoadAsync());
            InsertCommand = new RelayCommand(async () => await InsertAsync());
            UpdateCommand = new RelayCommand(async () => await UpdateAsync(), () => SelectedDolgozo != null);
            DeleteCommand = new RelayCommand(async () => await DeleteAsync(), () => SelectedDolgozo != null);

            _ = LoadAsync();
        }

        async Task LoadAsync()
        {
            Dolgozok.Clear();
            var lista = await _api.GetAllAsync();

            foreach (var d in lista)
            {
                d.ImageUrl = $"https://randomuser.me/api/portraits/men/{d.Id % 100}.jpg";
                Dolgozok.Add(d);
            }
            MessageBox.Show($"Betöltve: {Dolgozok.Count} dolgozó");
        }

        async Task InsertAsync()
        {
            if (SelectedDolgozo == null) return;
            await _api.InsertAsync(SelectedDolgozo);
            await LoadAsync();
        }

        async Task UpdateAsync()
        {
            await _api.UpdateAsync(SelectedDolgozo);
            await LoadAsync();
        }

        async Task DeleteAsync()
        {
            if (MessageBox.Show("Biztos törlöd?", "Törlés",
                MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            await _api.DeleteAsync(SelectedDolgozo.Id);
            await LoadAsync();
        }
    }
}
