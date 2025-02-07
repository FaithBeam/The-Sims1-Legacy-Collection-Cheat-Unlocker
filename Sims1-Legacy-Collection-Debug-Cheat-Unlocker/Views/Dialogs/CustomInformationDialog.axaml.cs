using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.Dialogs.CustomInformationDialog;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Views;

public partial class CustomInformationDialog : ReactiveWindow<CustomInformationDialogVm>
{
    public CustomInformationDialog()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
