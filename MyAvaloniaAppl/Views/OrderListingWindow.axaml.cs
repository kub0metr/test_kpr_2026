using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SukiUI.Controls;
using MyAvaloniaAppl.ViewModels;

namespace MyAvaloniaAppl.Views;

public partial class OrderListingWindow : SukiWindow
{
    public OrderListingWindow()
    {
        InitializeComponent();
        
        DataContext = new OrderListingModel();
    }
}