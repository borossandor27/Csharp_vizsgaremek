using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // ConfigurationManager használatához add hozzá a Reference-ekhez a System.Configuration-t
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace framework_WindowsFormsApp
{
    public partial class Form_Main : Form
    {
        static readonly string apiUrl = ConfigurationManager.AppSettings["RestApiBaseUrl"] ?? "https://retoolapi.dev/t0j7gq/dolgozok"; // A backend API URL-je
        static HttpClient _httpClient = new HttpClient(); 
        public readonly string ImageUrl = $"https://randomuser.me/api/portraits/men/"; // Minden dolgozóhoz random képet adunk 'ImageUrl+{id}.jpg'
        BindingList<Dolgozo> _dolgozok = new BindingList<Dolgozo>();
        BindingSource _bsDolgozok = new BindingSource();


        public Form_Main()
        {
            InitializeComponent();
        }

        private async void Form_Main_Load(object sender, EventArgs e)
        {
            pictureBox_dolgozo.Image = null;
            pictureBox_dolgozo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_dolgozo.MinimumSize = new Size(120, 120);

            numericUpDown_fizetes.Minimum = 0;
            numericUpDown_fizetes.Maximum =10000000;
            numericUpDown_fizetes.Value = 1000000;
            numericUpDown_fizetes.Increment = 10000;
            numericUpDown_fizetes.ThousandsSeparator = true;
            numericUpDown_fizetes.TextAlign = HorizontalAlignment.Right;

            listBox_dolgozok.DisplayMember = "TeljesNev";
            _bsDolgozok.DataSource = _dolgozok;

            listBox_dolgozok.DataSource = _bsDolgozok;

            pictureBox_dolgozo.DataBindings.Add(
                "ImageLocation",
                _bsDolgozok,
                "ImageUrl",
                true
            );

            await getAll_from_backend();
        }


        async Task getAll_from_backend()
        {
            var lista = Dolgozo.FromJson(
                await _httpClient.GetStringAsync(apiUrl)
            );

            _dolgozok.Clear();
            foreach (var d in lista)
            {
                d.ImageUrl = $"{ImageUrl}{d.Id}.jpg";
                _dolgozok.Add(d);
            }
        }

        private void listBox_dolgozok_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dolgozo selectedDolgozo = (Dolgozo)listBox_dolgozok.SelectedItem;
            if (selectedDolgozo != null)
            {
                textBox_id.Text = selectedDolgozo.Id.ToString();
                textBox_teljesnev.Text = selectedDolgozo.TeljesNev;
                textBox_beosztas.Text = selectedDolgozo.Beosztas;
                numericUpDown_fizetes.Value = selectedDolgozo.Fizetes;
                dateTimePicker_belepes.Value = DateTime.Parse(selectedDolgozo.Belepes);
                if (!string.IsNullOrEmpty(selectedDolgozo.Kilepes))
                {
                    dateTimePicker_kilepes.Value = DateTime.Parse(selectedDolgozo.Kilepes);
                    dateTimePicker_kilepes.Checked = true;
                }
                else
                {
                    dateTimePicker_kilepes.Checked = false;
                }
            }
        }

        async void button_insert_Click(object sender, EventArgs e)
        {
            var ujDolgozo = GetDolgozoFromForm();

            var json = JsonConvert.SerializeObject(ujDolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                await getAll_from_backend();
                MessageBox.Show("Dolgozó sikeresen hozzáadva");
            }
            else
            {
                MessageBox.Show("Hiba történt beszúráskor");
            }
        }


        async void button_getAll_Click(object sender, EventArgs e)
        {
            await getAll_from_backend();
        }

        async void button_update_Click(object sender, EventArgs e)
        {
            if (_bsDolgozok.Current == null) return;

            var dolgozo = GetDolgozoFromForm();

            var json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(
                $"{apiUrl}/{dolgozo.Id}",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                await getAll_from_backend();
                MessageBox.Show("Dolgozó frissítve");
            }
            else
            {
                MessageBox.Show("Hiba történt frissítéskor");
            }
        }


        async void button_delete_Click(object sender, EventArgs e)
        {
            if (_bsDolgozok.Current == null) return;

            var dolgozo = (Dolgozo)_bsDolgozok.Current;

            var confirm = MessageBox.Show(
                $"Biztosan törlöd: {dolgozo.TeljesNev}?",
                "Törlés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            var response = await _httpClient.DeleteAsync(
                $"{apiUrl}/{dolgozo.Id}"
            );

            if (response.IsSuccessStatusCode)
            {
                await getAll_from_backend();
                MessageBox.Show("Dolgozó törölve");
            }
            else
            {
                MessageBox.Show("Hiba történt törléskor");
            }
        }

        Dolgozo GetDolgozoFromForm()
        {
            return new Dolgozo
            {
                Id = int.TryParse(textBox_id.Text, out int id) ? id : 0,
                TeljesNev = textBox_teljesnev.Text,
                Beosztas = textBox_beosztas.Text,
                Fizetes = (int)numericUpDown_fizetes.Value,
                Belepes = dateTimePicker_belepes.Value.ToString("yyyy-MM-dd"),
                Kilepes = dateTimePicker_kilepes.Checked
                    ? dateTimePicker_kilepes.Value.ToString("yyyy-MM-dd")
                    : null
            };
        }

    }
}
