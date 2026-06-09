using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SukiUI.Controls;
using MyAvaloniaAppl.ViewModels;

namespace MyAvaloniaAppl.Views;

public partial class SecondWindow : SukiWindow
{
    public SecondWindow()
    {
        InitializeComponent();

        DataContext = new SecondWindowViewModel();
    }
}