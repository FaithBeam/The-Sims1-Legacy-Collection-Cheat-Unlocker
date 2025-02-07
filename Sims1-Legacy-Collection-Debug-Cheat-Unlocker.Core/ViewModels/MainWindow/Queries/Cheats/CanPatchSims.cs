using PatternFinder;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow.Queries.Cheats;

public static class CanPatchSims
{
    public sealed record Query(string PathToSims);

    public sealed class Handler
    {
        public bool Execute(Query q)
        {
            var pattern = Pattern.Transform(UnpatchedBytesPattern);
            var simsBytes = File.ReadAllBytes(q.PathToSims);
            return Pattern.Find(simsBytes, pattern, out _);
        }
        private const string UnpatchedBytesPattern = "807B4C007543";
    }
}