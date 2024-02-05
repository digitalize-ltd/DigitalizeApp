using DigitalizeApp.Base;

namespace DigitalizeApp.Services;

public interface INavigationService
{
    /// <summary>
    /// Returns the requested ViewModelBase from the application container.
    /// </summary>
    /// <typeparam name="T">The requested ViewModelBase type.</typeparam>
    /// <returns>The requested ViewModelBase.</returns>
    ViewModelBase NavigateTo<T>() where T : ViewModelBase;
}