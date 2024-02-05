using CommunityToolkit.Mvvm.ComponentModel;
using DigitalizeApp.Base;
using System;

namespace DigitalizeApp.Services;

public partial class NavigationService : ObservableObject, INavigationService
{
    #region init

    private readonly Func<Type, ViewModelBase> _viewModelFactory;

    #endregion

    #region constructor

    public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    #endregion

    #region public methods

    public ViewModelBase NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        // return the requested ViewModel
        return _viewModelFactory.Invoke(typeof(TViewModel));
    }

    #endregion
}