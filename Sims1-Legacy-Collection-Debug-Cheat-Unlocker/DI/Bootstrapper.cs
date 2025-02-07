using Microsoft.Extensions.DependencyInjection;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels;
using Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.DI;

public static class Bootstrapper
{
    public static void Register(IServiceCollection services)
    {
        MainWindowRegistrations.Register(services);
    }
}