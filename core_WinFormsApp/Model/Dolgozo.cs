using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace core_WinFormsApp.Model
{

    public class Dolgozo
    {
        public long Id { get; set; }
        public bool Aktiv { get; set; }

        [JsonPropertyName("Belepes")]
        public string BelepesString { get; set; } = "";

        [JsonIgnore]
        public DateOnly? BelepesDateOnly
        {
            get
            {
                if (string.IsNullOrEmpty(BelepesString))
                    return null;

                // Több formátumot próbáljunk meg
                string[] formats = {
                "yyyy-MM-dd",
                "MMM dd, yyyy h:mm tt",
                "MMM dd, yyyy",
                "yyyy.MM.dd",
                "dd/MM/yyyy"
            };

                if (DateTime.TryParseExact(BelepesString, formats,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    return DateOnly.FromDateTime(dateTime);
                }

                // Ha a TryParseExact nem működik, próbáljunk sima DateTime.Parse-t
                if (DateTime.TryParse(BelepesString, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    return DateOnly.FromDateTime(dateTime);
                }

                return null;
            }
        }

        [JsonIgnore]
        public string Belepes
        {
            get => BelepesDateOnly?.ToString("yyyy-MM-dd") ?? "";
            set => BelepesString = value;
        }

        public long Fizetes { get; set; }

        [JsonPropertyName("Kilepes")]
        public string? KilepesString { get; set; }

        [JsonIgnore]
        public DateOnly? KilepesDateOnly
        {
            get
            {
                if (string.IsNullOrEmpty(KilepesString))
                    return null;

                string[] formats = {
                "yyyy-MM-dd",
                "MMM dd, yyyy h:mm tt",
                "MMM dd, yyyy",
                "yyyy.MM.dd",
                "dd/MM/yyyy"
            };

                if (DateTime.TryParseExact(KilepesString, formats,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    return DateOnly.FromDateTime(dateTime);
                }

                if (DateTime.TryParse(KilepesString, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    return DateOnly.FromDateTime(dateTime);
                }

                return null;
            }
        }

        [JsonIgnore]
        public string? Kilepes
        {
            get => KilepesDateOnly?.ToString("yyyy-MM-dd");
            set => KilepesString = value;
        }

        public string Beosztas { get; set; } = "";
        public string Teljes_nev { get; set; } = "";

        public override string ToString()
        {
            return
                $"ID: {Id}\n" +
                $"\tNév: {Teljes_nev}\n" +
                $"\tBeosztás: {Beosztas}\n" +
                $"\tBelépés: {BelepesDateOnly?.ToString("yyyy-MM-dd") ?? BelepesString}\n" +
                $"\tKilépés: {KilepesDateOnly?.ToString("yyyy-MM-dd") ?? KilepesString ?? "N/A"}\n" +
                $"\tFizetés: {Fizetes}\n" +
                $"\tAktív: {Aktiv}\n";
        }
    }
}