using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace async_konzolos_framework47
{
    internal class Program
    {
        static readonly string apiUrl = ConfigurationManager.AppSettings["RestApiBaseUrl"] ?? "https://retoolapi.dev/t0j7gq/dolgozok";
        static HttpClient httpClient = new HttpClient();
        static List<Dolgozo> dolgozok = new List<Dolgozo>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Program indul");

            try
            {
                dolgozok = await ReadAllAsync();
                //foreach (var item in dolgozok)
                //{
                //    Console.WriteLine(item.ToString());
                //}

                int id = 3;
                Dolgozo dolgozo = await ReadIdAsync(id);

                if (dolgozo != null)
                {
                    Console.WriteLine(dolgozo.ToString());
                }
                else
                {
                    Console.WriteLine($"A(z) {id} azonosítójú dolgozó nem található.");
                }

                Dolgozo newDolgozo = new Dolgozo()
                {
                    Aktiv = true,
                    Beosztas = "fejlesztő",
                    Belepes = "2023-01-01",
                    Fizetes = 800000,
                    Kilepes = null,
                    TeljesNev = "Kiss János"
                };

                long newId = await InsertAsync(newDolgozo);

                if (newId > 0)
                {
                    Console.WriteLine($"Sikeres beszúrás, új ID: {newId}");
                }
                else
                {
                    Console.WriteLine("Sikertelen beszúrás");
                }

                if (dolgozo != null)
                {
                    dolgozo.Fizetes = 900000;
                    bool updateSuccess = await UpdateAsync(dolgozo);
                    if (updateSuccess)
                    {
                        Console.WriteLine("Sikeres frissítés");
                    }
                    else
                    {
                        Console.WriteLine("Sikertelen frissítés");
                    }
                }

                bool deleteSuccess = await DeleteAsync(id);
                if (deleteSuccess)
                {
                    Console.WriteLine("Sikeres törlés");
                }
                else
                {
                    Console.WriteLine("Sikertelen törlés");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }

            Console.WriteLine("Program vége!");
            Console.ReadKey();
        }

        private static async Task<bool> DeleteAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

        private static async Task<bool> UpdateAsync(Dolgozo dolgozo)
        {
            string json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{apiUrl}/{dolgozo.Id}", content);
            return response.IsSuccessStatusCode;
        }

        private static async Task<long> InsertAsync(Dolgozo dolgozo)
        {
            string json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);

            if (!response.IsSuccessStatusCode)
                return -1;

            string responseJson = await response.Content.ReadAsStringAsync();
            var inserted = JsonConvert.DeserializeObject<Dolgozo>(responseJson);

            return inserted.Id;
        }

        private static async Task<Dolgozo> ReadIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Dolgozo>(json);
        }

        private static async Task<List<Dolgozo>> ReadAllAsync()
        {
            var response = await httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return new List<Dolgozo>();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Dolgozo>>(json);
        }
    }
}