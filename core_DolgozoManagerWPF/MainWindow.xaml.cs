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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using core_WpfApp.Models;
using core_WpfApp.Services;



namespace core_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DolgozoApiService _service;
        private List<Dolgozo> _dolgozok = new List<Dolgozo>();

        public MainWindow()
        {
            InitializeComponent();
            _service = new DolgozoApiService("https://retoolapi.dev/t0j7gq/dolgozok");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDolgozokAsync();
        }

        private async Task LoadDolgozokAsync()
        {
            try
            {
                txtStatus.Text = "Betöltés...";
                _dolgozok = await _service.GetAllAsync();
                dgDolgozok.ItemsSource = null;
                dgDolgozok.ItemsSource = _dolgozok;
                txtStatus.Text = $"Betöltve: {_dolgozok.Count} dolgozó";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a betöltés során: {ex.Message}", "Hiba",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                txtStatus.Text = "Hiba történt";
            }
        }

        private void dgDolgozok_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgDolgozok.SelectedItem is Dolgozo selected)
            {
                txtId.Text = selected.Id.ToString();
                txtTeljesNev.Text = selected.Teljes_nev;
                txtBeosztas.Text = selected.Beosztas;
                txtFizetes.Text = selected.Fizetes.ToString();
                chkAktiv.IsChecked = selected.Aktiv;

                // Dátumok beállítása
                if (DateTime.TryParse(selected.Belepes, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime belepesDate))
                {
                    dpBelepes.SelectedDate = belepesDate;
                }

                if (!string.IsNullOrEmpty(selected.Kilepes) &&
                    DateTime.TryParse(selected.Kilepes, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime kilepesDate))
                {
                    dpKilepes.SelectedDate = kilepesDate;
                }
                else
                {
                    dpKilepes.SelectedDate = null;
                }
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTeljesNev.Text))
                {
                    MessageBox.Show("A név megadása kötelező!", "Figyelmeztetés",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!long.TryParse(txtFizetes.Text, out long fizetes))
                {
                    MessageBox.Show("Érvényes fizetést adjon meg!", "Figyelmeztetés",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var dolgozo = new Dolgozo
                {
                    Teljes_nev = txtTeljesNev.Text,
                    Beosztas = txtBeosztas.Text,
                    Fizetes = fizetes,
                    Aktiv = chkAktiv.IsChecked ?? true,
                    Belepes = dpBelepes.SelectedDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"),
                    Kilepes = dpKilepes.SelectedDate?.ToString("yyyy-MM-dd")
                };

                // Ha van ID, az egy meglévő dolgozó (bár a jelenlegi API nem támogatja a módosítást)
                if (long.TryParse(txtId.Text, out long id) && id > 0)
                {
                    dolgozo.Id = id;
                    // Jelenleg csak CREATE művelet van, de később lehetne UPDATE is
                    await _service.CreateAsync(dolgozo);
                    MessageBox.Show("Dolgozó létrehozva!", "Siker",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    await _service.CreateAsync(dolgozo);
                    MessageBox.Show("Dolgozó sikeresen létrehozva!", "Siker",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

                await LoadDolgozokAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a mentés során: {ex.Message}", "Hiba",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgDolgozok.SelectedItem is Dolgozo selected && selected.Id > 0)
            {
                var result = MessageBox.Show("Biztosan törli a kiválasztott dolgozót?", "Megerősítés",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _service.DeleteAsync(selected.Id);
                        await LoadDolgozokAsync();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba a törlés során: {ex.Message}", "Hiba",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy dolgozót a törléshez!", "Figyelmeztetés",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            dpBelepes.SelectedDate = DateTime.Now;
            chkAktiv.IsChecked = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadDolgozokAsync();
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtTeljesNev.Text = "";
            txtBeosztas.Text = "";
            txtFizetes.Text = "";
            dpBelepes.SelectedDate = null;
            dpKilepes.SelectedDate = null;
            chkAktiv.IsChecked = true;
        }

        private void txtFizetes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Csak számok engedélyezése
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
