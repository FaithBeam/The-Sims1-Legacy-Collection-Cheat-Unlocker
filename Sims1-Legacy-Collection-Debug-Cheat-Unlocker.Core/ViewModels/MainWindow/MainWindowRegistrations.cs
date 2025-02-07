using Microsoft.Extensions.DependencyInjection;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow.Commands;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow.Queries.Cheats;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow;

public static class MainWindowRegistrations
{
    public static void Register(IServiceCollection services)
    {
        services
            .AddScoped<MainWindowViewModel>()
            .AddScoped<CanPatchSims.Handler>()
            .AddScoped<PatchSimsExe.Handler>()
            .AddScoped<IsPatched.Handler>()
            .AddScoped<UnpatchSimsExe.Handler>();
    }
}
