using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using MyAvaloniaAppl.ViewModels;
using MyAvaloniaAppl.Views;
using System.IO;
using System;
using System.Text.Json;

namespace MyAvaloniaAppl;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    
}

public class AppConfig
{
    public string ApiBaseUrl{get;set;}
}

public static class JsonConfigurationF
{
    public static AppConfig LoadConfiguration()
    {
        string configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        string json = File.ReadAllText(configPath);
        return JsonSerializer.Deserialize<AppConfig>(json);
    }
}