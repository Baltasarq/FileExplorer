// (c) 2026 FileExplorer Baltasar MIT License <jbgarcia@uvigo.gal>


namespace FileExplorer.View;


using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;


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
            desktop.MainWindow = new MainWindowControl().View;
        }

        base.OnFrameworkInitializationCompleted();
    }
}