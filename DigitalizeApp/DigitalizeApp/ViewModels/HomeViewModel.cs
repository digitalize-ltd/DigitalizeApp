using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DigitalizeApp.Base;
using DigitalizeApp.Events;
using DigitalizeApp.Pages;

namespace DigitalizeApp.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    #region commands

    [RelayCommand]
    private void OpenPlanetaryDefenses()
    {
        WeakReferenceMessenger.Default.Send(new NavigationRequestEvent(PageName.PlanetaryDefenses));
    }

    [RelayCommand]
    private void OpenAGI()
    {
        WeakReferenceMessenger.Default.Send(new NavigationRequestEvent(PageName.AGI));
    }

    [RelayCommand]
    private void OpenEnergyLevels()
    {
        WeakReferenceMessenger.Default.Send(new NavigationRequestEvent(PageName.EnergyLevels));
    }

    #endregion
}
