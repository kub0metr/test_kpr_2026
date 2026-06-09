using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyAvaloniaAppl.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{   
    [ObservableProperty]
    private string _myText = "my text";

    
}
