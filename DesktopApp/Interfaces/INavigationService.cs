using System.Windows.Controls;

namespace DesktopApp.Interfaces;

public interface INavigationService
{
    void NavigateTo<TView>() where TView : UserControl;
}