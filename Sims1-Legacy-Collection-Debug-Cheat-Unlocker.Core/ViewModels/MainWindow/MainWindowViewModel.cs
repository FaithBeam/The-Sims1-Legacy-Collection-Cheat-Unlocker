using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow.Commands;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow.Queries.Cheats;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    public string? PathToSims
    {
        get => _pathToSims;
        set => this.RaiseAndSetIfChanged(ref _pathToSims, value);
    }

    private bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    public ReactiveCommand<Unit, string?> BrowseCmd { get; }
    public IInteraction<Unit, string?> BrowseInteraction { get; }
    public ReactiveCommand<string, Unit> PatchCmd { get; }
    public ReactiveCommand<string, Unit> UnPatchCmd { get; }

    public MainWindowViewModel(
        CanPatchSims.Handler canPatchSimsHandler,
        IsPatched.Handler isPatchedHandler,
        PatchSimsExe.Handler patchSimsExeHandler,
        UnpatchSimsExe.Handler unpatchSimsExeHandler
    )
    {
        BrowseInteraction = new Interaction<Unit, string?>();
        var canBrowse = this.WhenAnyValue(x => x.IsBusy, selector: isBusy => !isBusy);
        BrowseCmd = ReactiveCommand.CreateFromTask<string?>(
            async () => await BrowseInteraction.Handle(Unit.Default),
            canBrowse
        );

        BrowseCmd.Subscribe(x => PathToSims = x);

        var canPatch = this.WhenAnyValue(
            x => x.PathToSims,
            x => x.IsBusy,
            selector: (pathToSims, isBusy) =>
                !isBusy
                && !string.IsNullOrWhiteSpace(pathToSims)
                && File.Exists(pathToSims)
                && canPatchSimsHandler.Execute(new CanPatchSims.Query(pathToSims))
        );
        PatchCmd = ReactiveCommand.Create<string>(
            pathToSims =>
            {
                IsBusy = true;
                patchSimsExeHandler.Execute(new PatchSimsExe.Command(pathToSims));
                IsBusy = false;
            },
            canPatch
        );

        var canUnPatch = this.WhenAnyValue(
            x => x.PathToSims,
            x => x.IsBusy,
            selector: (pathToSims, isBusy) =>
                !isBusy
                && !string.IsNullOrWhiteSpace(pathToSims)
                && File.Exists(pathToSims)
                && isPatchedHandler.Execute(new IsPatched.Query(pathToSims))
        );
        UnPatchCmd = ReactiveCommand.Create<string>(
            pathToSims =>
            {
                IsBusy = true;
                unpatchSimsExeHandler.Execute(new UnpatchSimsExe.Command(pathToSims));
                IsBusy = false;
            },
            canUnPatch
        );
    }

    private string? _pathToSims;
    private bool _isBusy;
}
