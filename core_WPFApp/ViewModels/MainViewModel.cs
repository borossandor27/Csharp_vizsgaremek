using core_WpfApp.Models;
using core_WpfApp.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace core_WpfApp.ViewModels
{
    public class MainViewModel
    {
        private readonly DolgozoApiService _apiService;
        public ObservableCollection<Dolgozo> Dolgozok { get; } = new();

        public ICommand LoadDolgozokCommand { get; }
        public ICommand DeleteDolgozoCommand { get; }

        public MainViewModel(DolgozoApiService apiService)
        {
            _apiService = apiService;

            LoadDolgozokCommand = new RelayCommand(async () => await LoadDolgozok());
            DeleteDolgozoCommand = new RelayCommand<long>(async id => await DeleteDolgozo(id));
        }

        private async Task LoadDolgozok()
        {
            try
            {
                var dolgozok = await _apiService.GetAllAsync();
                Dolgozok.Clear();
                foreach (var dolgozo in dolgozok)
                {
                    Dolgozok.Add(dolgozo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba az adatok betöltésekor: {ex.Message}");
            }
        }

        private async Task DeleteDolgozo(long id)
        {
            try
            {
                await _apiService.DeleteAsync(id);
                await LoadDolgozok(); // Frissítsd a listát
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a törléskor: {ex.Message}");
            }
        }
    }
}