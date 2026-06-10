using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaAppl.Views;
using System.Collections.ObjectModel;
using AvApplRepo.HttpService;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System;
using Tmds.DBus.Protocol;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace MyAvaloniaAppl.ViewModels;

public partial class SecondWindowViewModel : ObservableObject
{
     [ObservableProperty]
    private ObservableCollection<Products> _items = new();

    [ObservableProperty]
    private string _searchText = string.Empty;

[ObservableProperty]
private string _answerText = string.Empty;

    [RelayCommand]
    private async void AddNPr()
    {
        
        
        var response = await server.DownloadHexFile();

         Items = JsonSerializer.Deserialize<ObservableCollection<Products>>(response);
       
    }



  GiteaService server;
public string    apiUrl ;

 public SecondWindowViewModel()
    {
        
        var config =JsonConfigurationF.LoadConfiguration();
        apiUrl = config.ApiBaseUrl;

server = new GiteaService(apiUrl);


        // Наполняем тестовыми данными
        Items.Add(new Products {  ProductName="Croissant", Category="Tarte", Price=4.32f,  Cost= 3.3f});
        //Items.Add(new Products {  Name = "Елена"});
    }


    [RelayCommand]
    private async void Action()
    {
        var newProduct = new Products{ProductName = "Bulochka", Cost=82.5f, Price=90, Category="BREAD"};
string json = JsonSerializer.Serialize(newProduct);
        AnswerText = await server.ResponseM(json);
       //var addedprW = new AddEdProductWindow();
        //addedprW.Show();
    }
}


// Простая модель данных для таблицы
public partial class Products : ObservableObject
{
    //[ObservableProperty]
    
    //public partial  bool Active { get; set; } = false;
    [ObservableProperty]
    [JsonPropertyName("name")]
    public partial  string ProductName { get; set; } = string.Empty;
    [ObservableProperty]
    [JsonPropertyName("category")]
    public partial  string Category { get; set; } = string.Empty;
    [ObservableProperty]
    [JsonPropertyName("price")]
    public partial  float Price { get; set; } = 0;
    [ObservableProperty]
    [JsonPropertyName("cost")]
    public partial  float Cost { get; set; } = 0;
     //public string Action {publicpublic get; set; } = string.Empty;

}