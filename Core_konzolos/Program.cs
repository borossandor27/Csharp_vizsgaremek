Console.WriteLine("Program indul!");

var service = new DolgozoApiService(
    "https://retoolapi.dev/t0j7gq/dolgozok"
);

// GET ALL
var dolgozok = await service.GetAllAsync();
Console.WriteLine($"Beolvasva: {dolgozok.Count} dolgozó\n");

foreach (var d in dolgozok)
{
    Console.WriteLine(d);
}

// CREATE
var ujDolgozo = new Dolgozo
{
    Aktiv = true,
    Belepes = "2024-01-15",
    Fizetes = 550000,
    Beosztas = "Fejlesztő",
    Teljes_nev = "Kovács János"
};

// await service.CreateAsync(ujDolgozo);

// GET BY ID
var dolgozo1 = await service.GetByIdAsync(1);
if (dolgozo1 != null)
{
    Console.WriteLine("Lekért dolgozó:");
    Console.WriteLine(dolgozo1);
}

Console.WriteLine("Program vége!");
Console.ReadLine();
