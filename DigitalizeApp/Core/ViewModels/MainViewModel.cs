using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Core.Base;
using Core.Events;
using Core.Pages;
using Core.Services;

namespace Core.ViewModels;

public partial class MainViewModel : NavPageViewModel
{
    #region init

    private readonly INavigationService _navigationService;

    #endregion

    #region public properties

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomeButtonVisible))]
    private PageName _currentPage;

    [ObservableProperty]
    private ViewModelBase _content;
    
    public bool HomeButtonVisible => CurrentPage != PageName.Home;

    #endregion

    #region commands

    [RelayCommand]
    private void GoHome()
    {
        Content = _navigationService.NavigateTo<HomeViewModel>();
        CurrentPage = PageName.Home;
    }

    #endregion

    #region constructor

    /// <summary>
    /// Design time constructor.
    /// </summary>
    public MainViewModel()
    {
        Content = new HomeViewModel();
    }

    /// <summary>
    /// DI constructor.
    /// </summary>
    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        SetupNavigation();

        Content = _navigationService.NavigateTo<HomeViewModel>();
    }

    #endregion

    #region navigation

    protected override void SetupNavigation()
    {
        WeakReferenceMessenger.Default.Register<NavigationRequestEvent>(this, (r, m) =>
        {
            switch (m.Page)
            {
                case PageName.PlanetaryDefenses:

                    Content = _navigationService.NavigateTo<PlanetaryDefensesViewModel>();
                    CurrentPage = PageName.PlanetaryDefenses;

                    break;

                case PageName.AGI:

                    Content = _navigationService.NavigateTo<AGIViewModel>();
                    CurrentPage = PageName.AGI;

                    break;

                case PageName.EnergyLevels:

                    Content = _navigationService.NavigateTo<EnergyViewModel>();
                    CurrentPage = PageName.EnergyLevels;

                    break;

                default:
                    break;
            }
        });
    }

    #endregion
}
