using core_WinFormsApp.Model;
using core_WinFormsApp.Services;

namespace core_WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly DolgozoApiService _service;
        private List<Dolgozo> _dolgozok = new List<Dolgozo>();

        public MainForm()
        {
            InitializeComponent();
            _service = new DolgozoApiService("https://retoolapi.dev/t0j7gq/dolgozok");
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDolgozokAsync();
        }

        private async Task LoadDolgozokAsync()
        {
            try
            {
                dataGridView1.DataSource = null;
                _dolgozok = await _service.GetAllAsync();
                dataGridView1.DataSource = _dolgozok;
                lblStatus.Text = $"Betöltve: {_dolgozok.Count} dolgozó";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a betöltés során: {ex.Message}", "Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Dolgozo selected)
            {
                txtNev.Text = selected.Teljes_nev;
                txtBeosztas.Text = selected.Beosztas;
                txtFizetes.Text = selected.Fizetes.ToString();
                dtpBelepes.Value = DateTime.Parse(selected.Belepes);
                chkAktiv.Checked = selected.Aktiv;
                txtId.Text = selected.Id.ToString();
            }
        }

        private async void btnUj_Click(object sender, EventArgs e)
        {
            try
            {
                var ujDolgozo = new Dolgozo
                {
                    Teljes_nev = txtNev.Text,
                    Beosztas = txtBeosztas.Text,
                    Fizetes = long.Parse(txtFizetes.Text),
                    Belepes = dtpBelepes.Value.ToString("yyyy-MM-dd"),
                    Aktiv = chkAktiv.Checked
                };

                await _service.CreateAsync(ujDolgozo);
                MessageBox.Show("Dolgoző sikeresen hozzáadva!", "Siker",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDolgozokAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a mentés során: {ex.Message}", "Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTorles_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var result = MessageBox.Show("Biztosan törli a dolgozót?", "Megerősítés",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await _service.DeleteAsync(long.Parse(txtId.Text));
                        await LoadDolgozokAsync();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba a törlés során: {ex.Message}", "Hiba",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUjites_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtNev.Text = "";
            txtBeosztas.Text = "";
            txtFizetes.Text = "";
            dtpBelepes.Value = DateTime.Now;
            chkAktiv.Checked = true;
        }

        private async void btnFrissit_Click(object sender, EventArgs e)
        {
            await LoadDolgozokAsync();
        }

        private void txtFizetes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Csak számok engedélyezése
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
