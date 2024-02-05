using Avalonia.Controls;
using Avalonia.Input;
using System;

namespace Core.Views;

public partial class Shell : Window
{
    public Shell()
    {
        InitializeComponent();
        ExtendClientAreaTitleBarHeightHint = -1;
    }

    private void Window_ExitPressed(object? sender, PointerPressedEventArgs e)
    {
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
        {
            Close();
        });
    }
}
