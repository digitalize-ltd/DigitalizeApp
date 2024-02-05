namespace DigitalizeApp.Base;

public abstract class NavPageViewModel : ViewModelBase
{
    #region constructor

    protected NavPageViewModel() : base() { }

    #endregion

    #region abstract methods

    /// <summary>
    /// Navigation setup.
    /// </summary>
    protected abstract void SetupNavigation();

    #endregion

}
