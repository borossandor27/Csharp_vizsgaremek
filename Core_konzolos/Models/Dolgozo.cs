
using System;
using System.Collections.Generic; // Gyűjtemények kezeléséhez

using System.Globalization; // Nemzeti információk kezeléséhez
using System.Text.Json;


public class Dolgozo
{
    public long Id { get; set; }
    public bool Aktiv { get; set; }
    public string Belepes { get; set; }
    public DateOnly BelepesDateOnly
    {
        get
        {
            return DateOnly.ParseExact(Belepes, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
    public long Fizetes { get; set; }
    public string? Kilepes { get; set; }
    public DateOnly? KilepesDateOnly
    {
        get
        {
            if (string.IsNullOrEmpty(Kilepes))
            {
                return null;
            }
            return DateOnly.ParseExact(Kilepes, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
    public string Beosztas { get; set; } = "";
    public string Teljes_nev { get; set; } = "";

    public override string ToString()
    {
        return
            $"ID: {Id}\n" +
            $"\tNév: {Teljes_nev}\n" +
            $"\tBeosztás: {Beosztas}\n" +
            $"\tBelépés: {Belepes}\n" +
            $"\tKilépés: {Kilepes ?? "N/A"}\n" +
            $"\tFizetés: {Fizetes}\n" +
            $"\tAktív: {Aktiv}\n";
    }
}



