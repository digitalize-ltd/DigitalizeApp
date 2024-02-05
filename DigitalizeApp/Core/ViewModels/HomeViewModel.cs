using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Core.Base;
using Core.Events;
using Core.Pages;

namespace Core.ViewModels;

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
