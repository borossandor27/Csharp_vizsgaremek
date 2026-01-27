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

