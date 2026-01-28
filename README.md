# REST API használata C#-ban

A több mint 20 éve folyamatosan fejlődő nyelv több lehetőséget kínál. Választhatsz `.NET Framework` és `.NET` között, 
valamint `WinForm` és `WPF` között. A `.NET Framework` fejlesztése leállt és 
csak MS Windows alatt működőképes, de egy ügyviteli alkalmazáshoz még most is 
kiválóan megfelel. A WPF grafikai szolgltatásai sokkal jobbal a WinForm-hoz képest
 Más alkalmazásoknál egyértelműen a `.NET` az ajánlott. 
 
## JSON-ből C# object

Az internetes adatcsere legnagyobb részében a JSON-t használjuk. `.NETFramework` közvetlenül nem támogatja ezt a formátumot. 
Kezelésére a legjobb választás a `Newtonsoft.JSON` csomag.  
Alkalmazáson belül adattagokat és metódusokat is tartalmazó objektumot kell készíteni belőle, 
hogy rugalmasan hesználni tudjuk. Nagyon sok online szolgáltató elkészíti nekünk. pl. a https://app.quicktype.io/
1. adjuk hozzá a projektünkhöz a Newtonsoft-ot a NuGet csomagkezelő segítségével
1. Másoljuk be a JSON-t
1. Adjuk meg az kívánt osztálynevet
1. Válasszuk a `List<T>`-t
1. Adjuk meg a NameSpace értékünket
1. A projekthez addjunk hozzá egy ilyen nevű osztálynevet
1. A létrejött osztályba másoljuk be weblapról a teljes kódot

## Feladatok

- GET all
- GET by id
- POST
- PUT
- DELETE

## .NETFramework

### Konzolos

### WinForm

### WPF 

### REST API adatelérési osztály

## .NET

### Konzolos

### WinForm

### WPF 

### REST API adatelérési osztály

## Összefoglalás

|                                                                                                | WinForms                                                                  | WPF                                                            | WinForms                                                                                                                                | WPF                                                                                                                           |
| ---------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| Kategória / Téma                                                                               | .NET Framework                                                            | .NET Framework                                                 | .NET (Core)                                                                                                                             | .NET (Core)                                                                                                                   |
| Alkalmazás típus                                                                               | WinForms                                                                  | WPF                                                            | WinForms                                                                                                                                | WPF                                                                                                                           |
| Futási környezet                                                                               | .NET Framework 4.x (Windows)                                              | .NET Framework 4.x (Windows)                                   | .NET 6/7/8+ (Keresztplatformos)                                                                                                         | .NET 6/7/8+ (Keresztplatformos)                                                                                               |
| Végpont elérés objektuma                                                                       | HttpClient                                                                | HttpClient                                                     | HttpClient (javasolt: IHttpClientFactory)                                                                                               | HttpClient (javasolt: IHttpClientFactory)                                                                                     |
| JSON támogatás                                                                                 | Külső: Newtonsoft.Json                                                    | Külső: Newtonsoft.Json                                         | Alapértelmezett: System.Text.Json                                                                                                       | Alapértelmezett: System.Text.Json                                                                                             |
| Alapértelmezett: nincs                                                                         | Alapértelmezett: nincs                                                    | Lehetséges: Newtonsoft.Json                                    | Lehetséges: Newtonsoft.Json                                                                                                             |
| Config kezelés                                                                                 | System.Configuration (App.config, Web.config)                             | System.Configuration (App.config)                              | Microsoft.Extensions.Configuration (appsettings.json, környezeti változók, stb.)                                                        | Microsoft.Extensions.Configuration (appsettings.json, környezeti változók, stb.)                                              |
| Ajánlott lista elem (DataBinding)                                                              | BindingList<T> (a List<T> helyett)                                        | ObservableCollection<T> (WPF ajánlott, erősebb értesítés)      | BindingList<T> (a List<T> helyett)                                                                                                      | ObservableCollection<T> (WPF ajánlott, erősebb értesítés)                                                                     |
| BindingList<T> is működik, de nem optimális.                                                   |
| Vezérlők                                                                                       | DateTimePicker, NumericUpDown, DataGridView, stb. (Gazdag, érett készlet) | Nincs beépített DateTimePicker, NumericUpDown.                 | Magas kompatibilitás: Ugyanazok, mint .NET Framework WinForms, modernizálva.                                                            | Ugyanaz, mint .NET Framework WPF (az Extended WPF Toolkit is támogatott).                                                     |
| Megoldások: Külső könyvtár (pl. Extended WPF Toolkit), Custom Control, Windows API integráció. |
| Gyorsítás, újítások                                                                            | Lassabb fejlődés, nincsenek modern optimalizációk.                        | Lassabb fejlődés, nincsenek modern optimalizációk.             | Magasabb teljesítmény: JIT optimalizációk, több szál párhuzamosítása (pl. GC).                                                          | Magasabb teljesítmény: Jobb renderelés (pl. DirectX 11/12), modern futási idő.                                                |
| Telepítés / Szerelvény neve                                                                    | Nincs szabvány, általában a Company.Product.exe formátum.                 | Nincs szabvány, általában a Company.Product.exe formátum.      | Tisztább struktúra: Company.Product.exe, és Company.Product.dll a fő logikához.                                                         | Tisztaabb struktúra: Company.Product.exe, és Company.Product.dll a fő logikához.                                              |
| Összefoglalás                                                                                  | Stabil, érett, de régi technológia. Új projektre nem ajánlott.            | Stabil, érett, de régi technológia. Új projektre nem ajánlott. | WinForms modernizálva: Keresztplatformos lehetőség, jobb teljesítmény, modern fejlesztési élmény. Új projektekre ajánlott, ha WinForms. | WPF modernizálva: Keresztplatformos lehetőség, jobb teljesítmény, modern fejlesztési élmény. Új projektekre ajánlott, ha WPF. |

