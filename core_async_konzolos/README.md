# Követendők a .NET 6–8 szabvány szerint:

- top-level `Program.cs` fájl
- `Host.CreateDefaultBuilder` használata
- **Typed HttpClient** használata
- csak ***Dependency injection (DI)***-ból jön minden
- async/await mindenhol
- `System.Net.Http.Json` használata JSON kezelésre
- nincs `new Service(...)` sehol