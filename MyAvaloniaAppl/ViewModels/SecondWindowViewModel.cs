using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaAppl.Views;
using System.Collections.ObjectModel;

namespace MyAvaloniaAppl.ViewModels;

public partial class SecondWindowViewModel : ObservableObject
{
    
 // 2. Генератор сам создаст публичное свойство UsersData (с большой буквы)
    [ObservableProperty]
    private ObservableCollection<UserItem> _items = new();

 public SecondWindowViewModel()
    {
        // Наполняем тестовыми данными
        Items.Add(new UserItem {  Name = "Алексей" });
        Items.Add(new UserItem {  Name = "Елена"});
    }
}


// Простая модель данных для таблицы
public class UserItem
{
    //public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    //public string Role { get; set; } = string.Empty;
}