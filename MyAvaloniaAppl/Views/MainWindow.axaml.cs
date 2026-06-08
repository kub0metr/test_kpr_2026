using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Controls;
using AvApplRepo.HttpService;



namespace MyAvaloniaAppl.Views;

public partial class MainWindow : Window
{
    //private readonly HttpClient _httpCl;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GiteaService server = new GiteaService();

        AppText.Text = await server.DownloadHexFile();
    }
}