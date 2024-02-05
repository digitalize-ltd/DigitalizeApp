using DigitalizeApp.Base;
using DigitalizeApp.Services;
using DigitalizeApp.ViewModels;
using DigitalizeApp.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DigitalizeApp.Hosting;

public static class ApplicationExtensions
{
    /// <summary>
    /// Adds application configuration via environment variables.
    /// </summary>
    /// <param name="appBuilder">The host builder.</param>
    /// <returns>The updated host builder.</returns>
    public static IHostApplicationBuilder AddApplicationConfiguration(this IHostApplicationBuilder appBuilder)
    {
        appBuilder.Configuration.SetBasePath(basePath: AppContext.BaseDirectory);
        appBuilder.Configuration.AddEnvironmentVariables();

        return appBuilder;
    }

    /// <summary>
    /// Registers application services.
    /// </summary>
    /// <param name="appBuilder">The host builder.</param>
    /// <returns>The updated host builder.</returns>
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<INavigationService, NavigationService>();

        appBuilder.Services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider =>
        viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

        appBuilder.Services.AddSingleton<ViewLocator>();

        return appBuilder;
    }

    /// <summary>
    /// Registers application content.
    /// </summary>
    /// <param name="appBuilder">The host builder.</param>
    /// <returns>The updated host builder.</returns>
    public static IHostApplicationBuilder AddContent(this IHostApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<MainViewModel>();
        appBuilder.Services.AddSingleton<HomeViewModel>();
        appBuilder.Services.AddSingleton<PlanetaryDefensesViewModel>();
        appBuilder.Services.AddSingleton<AGIViewModel>();
        appBuilder.Services.AddSingleton<EnergyViewModel>();

        appBuilder.Services.AddSingleton((serviceProvider) => new Shell() { DataContext = serviceProvider.GetRequiredService<MainViewModel>() });

        appBuilder.Services.AddSingleton((serviceProvider) => new MainView() { DataContext = serviceProvider.GetRequiredService<MainViewModel>() });

        return appBuilder;
    }
}