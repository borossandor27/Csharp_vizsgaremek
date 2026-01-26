
    using System;
    using System.Collections.Generic;

    using System.Globalization;
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
    public string TeljesNev { get; set; } = "";

    public override string ToString()
    {
        return
            $"ID: {Id}\n" +
            $"Név: {TeljesNev}\n" +
            $"Beosztás: {Beosztas}\n" +
            $"Belépés: {Belepes}\n" +
            $"Kilépés: {Kilepes ?? "N/A"}\n" +
            $"Fizetés: {Fizetes}\n" +
            $"Aktív: {Aktiv}\n";
    }
}



