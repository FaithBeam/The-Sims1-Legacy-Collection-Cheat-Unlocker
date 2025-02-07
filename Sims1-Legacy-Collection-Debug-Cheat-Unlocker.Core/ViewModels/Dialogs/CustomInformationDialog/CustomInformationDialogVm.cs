using ReactiveUI;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.Dialogs.CustomInformationDialog;

public class CustomInformationDialogVm(string title, string message) : ReactiveObject
{
    public string Title { get; } = title;
    public string Message { get; } = message;
}