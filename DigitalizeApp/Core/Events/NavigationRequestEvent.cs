using Core.Pages;

namespace Core.Events;

public class NavigationRequestEvent
{
    #region public properties

    public PageName Page { get; }

    #endregion

    #region constructor

    public NavigationRequestEvent(PageName value)
    {
        Page = value;
    }

    #endregion
}