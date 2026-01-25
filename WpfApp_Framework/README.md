# WPF .NETFramework-ben

Egy Windows Forms alkalmazás átültetése WPF (Windows Presentation Foundation) alapokra nemcsak vizuális megújulást jelent, hanem szemléletváltást is: a Windows Forms eseményvezérelt (Code-behind) megközelítése helyett WPF-ben az MVVM (Model-View-ViewModel) minta és az adatkötés (Data Binding) a preferált út.

Mivel a projekt továbbra is .NET Framework 4.7.2 alapú marad, az üzleti logika (a Dolgozo osztály és az API hívások) nagy része változatlanul átmenthető.

WPF-ben ahhoz, hogy a felület automatikusan frissüljön, ha egy objektum adata megváltozik, az osztálynak implementálnia kell az `INotifyPropertyChanged` interfészt.