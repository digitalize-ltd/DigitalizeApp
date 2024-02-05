using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using DigitalizeApp.Hosting;
using DigitalizeApp.ViewModels;
using DigitalizeApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DigitalizeApp;

public partial class App : Application
{
    #region constructor

    public App() { }

    #endregion

    #region overrides

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        var host = CreateHostBuilder().Build();

        var viewLocator = host.Services.GetRequiredService<ViewLocator>();
        DataTemplates.Add(viewLocator);

        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT.
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = host.Services.GetRequiredService<Shell>();

            desktop.Exit += (sender, args) =>
            {
                host.StopAsync(TimeSpan.FromSeconds(2)).GetAwaiter().GetResult();
                host.Dispose();
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = host.Services.GetRequiredService<MainView>();
        }

        base.OnFrameworkInitializationCompleted();

        await host.StartAsync();
    }

    #endregion

    #region helper methods

    /// <summary>
    /// Creates and configures the application host.
    /// </summary>
    /// <param name="args">Host builder arguments.</param>
    /// <returns>The HostApplicationBuilder.</returns>
    public static HostApplicationBuilder CreateHostBuilder()
    {
        return (HostApplicationBuilder)Host.CreateApplicationBuilder()
            .AddApplicationConfiguration()
            .AddServices()
            .AddContent();
    }

    #endregion
}