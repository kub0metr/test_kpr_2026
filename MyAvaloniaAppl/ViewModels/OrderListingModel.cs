using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaAppl.Views;
using System.Collections.ObjectModel;

namespace MyAvaloniaAppl.ViewModels;

public partial class OrderListingModel : ObservableObject
{
    
 [ObservableProperty]
    private string _searchText = string.Empty;


    [RelayCommand]
    private void AddNPr()
    {
        
    }



 /// <summary>
 /// Коллекция данных для Таблицы
 /// </summary>
    [ObservableProperty]
    private ObservableCollection<Orders> _items = new();

      [RelayCommand]
    private void Action()
    {
       var addedprW = new AddEdProductWindow();
        addedprW.Show();
    }
 public OrderListingModel()
    {
        // Наполняем тестовыми данными
        Items.Add(new Orders {Active=false,  ProductName="Croissant", Category="Tarte", Price=4.32f,  Cost= 3.3f});
        //Items.Add(new Products {  Name = "Елена"});
    }
}

public class Orders
{
    public bool Active { get; set; } = false;
    public string ProductName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public float Price { get; set; } = 0;
    public float Cost { get; set; } = 0;
     //public string Action { get; set; } = string.Empty;

}