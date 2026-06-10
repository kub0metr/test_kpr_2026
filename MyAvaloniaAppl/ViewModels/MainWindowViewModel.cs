using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaAppl.Views;

namespace MyAvaloniaAppl.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{   

    [RelayCommand]
    private void ProdMan()
    {
        var secondW = new SecondWindow();
        secondW.Show();

    }

      [RelayCommand]
    private void OrderListing()
    {
        var secondW = new OrderListingWindow();
        secondW.Show();

    }
}
