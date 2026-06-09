using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaAppl.Views;
using System.Collections.ObjectModel;

namespace MyAvaloniaAppl.ViewModels;

public partial class SecondWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _searchText = string.Empty;


    [RelayCommand]
    private void AddNPr()
    {
        
    }



 
    [ObservableProperty]
    private ObservableCollection<Products> _items = new();

 public SecondWindowViewModel()
    {
        // Наполняем тестовыми данными
        Items.Add(new Products {Active=false,  ProductName="Croissant", Category="Tarte", Price=4.32f,  Cost= 3.3f});
        //Items.Add(new Products {  Name = "Елена"});
    }


    [RelayCommand]
    private void Action()
    {
       var addedprW = new AddEdProductWindow();
        addedprW.Show();
    }
}


// Простая модель данных для таблицы
public partial class Products : ObservableObject
{
    [ObservableProperty]
    public partial  bool Active { get; set; } = false;
    [ObservableProperty]
    public partial  string ProductName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial  string Category { get; set; } = string.Empty;
    [ObservableProperty]
    public partial  float Price { get; set; } = 0;
    [ObservableProperty]
    public partial  float Cost { get; set; } = 0;
     //public string Action {publicpublic get; set; } = string.Empty;

}