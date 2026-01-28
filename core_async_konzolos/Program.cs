using Core_konzolos.Models;
using Core_konzolos.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Program indul!");

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.AddHttpClient<DolgozoApiService>(client =>
    {
        client.BaseAddress = new Uri(
            context.Configuration["RestApiBaseUrl"]
            ?? "https://retoolapi.dev/t0j7gq/dolgozok"
        );
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });
});

var host = builder.Build();

// CORRECTED: Get the DolgozoApiService from DI, not DolgozoApi
var service = host.Services.GetRequiredService<DolgozoApiService>();

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