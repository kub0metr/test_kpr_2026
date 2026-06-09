using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaAppl.Views;

namespace MyAvaloniaAppl.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{   


    [ObservableProperty]
    private string _myText = "my text";

     [ObservableProperty]
    private string _userName = string.Empty;

    [RelayCommand]
    private void InputClick()
    {
        var secondW = new SecondWindow();
        secondW.Show();
        
    }
}
