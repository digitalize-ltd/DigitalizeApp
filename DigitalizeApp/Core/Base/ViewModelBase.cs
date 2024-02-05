using CommunityToolkit.Mvvm.ComponentModel;

namespace Core.Base;

public abstract partial class ViewModelBase : ObservableObject
{
    #region constructor

    protected ViewModelBase() : base() { }

    #endregion
}
