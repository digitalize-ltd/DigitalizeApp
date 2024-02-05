using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Core.Base;
using System;

namespace Core;

public class ViewLocator : IDataTemplate
{
    public static bool SupportsRecycling => false;

    public Control? Build(object? data)
    {
        var name = data!.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }
        else
        {
            return new TextBlock { Text = "Not Found: " + name };
        }
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}