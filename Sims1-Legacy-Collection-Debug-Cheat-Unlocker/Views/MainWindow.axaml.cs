using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.Dialogs.CustomInformationDialog;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d =>
        {
            if (ViewModel is null)
            {
                return;
            }

            ViewModel.BrowseInteraction.RegisterHandler(OpenFilePickerHandler).DisposeWith(d);
            ViewModel
                .CustomInformationDialogInteraction.RegisterHandler(ShowCustomInformationDialog)
                .DisposeWith(d);
        });
    }

    private async Task ShowCustomInformationDialog(
        IInteractionContext<CustomInformationDialogVm, Unit> interactionCtx
    )
    {
        var dlg = new CustomInformationDialog { DataContext = interactionCtx.Input };
        await dlg.ShowDialog(this);
        interactionCtx.SetOutput(Unit.Default);
    }

    private async Task OpenFilePickerHandler(IInteractionContext<Unit, string?> interaction)
    {
        var files = await StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions()
            {
                Title = "Select Sims.exe",
                AllowMultiple = false,
                FileTypeFilter = [new FilePickerFileType("Sims.exe") { Patterns = ["Sims.exe"] }],
            }
        );
        interaction.SetOutput(files.Any() ? files[0].TryGetLocalPath() : null);
    }
}
