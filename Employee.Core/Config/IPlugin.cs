using System;
using System.Windows;

namespace Employee.Core.Config
{
    public interface IPlugin : IServiceProvider, IDisposable
    {
        FrameworkElement CreateControl();
    }
}
