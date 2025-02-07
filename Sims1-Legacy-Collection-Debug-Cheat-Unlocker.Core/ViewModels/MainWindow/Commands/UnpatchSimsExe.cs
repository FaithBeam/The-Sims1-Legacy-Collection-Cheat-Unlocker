using PatternFinder;

namespace Sims1_Legacy_Collection_Debug_Cheat_Unlocker.Core.ViewModels.MainWindow.Commands;

public static class UnpatchSimsExe
{
    public sealed record Command(string PathToSims);

    public sealed class Handler
    {
        public void Execute(Command c)
        {
            var pattern = Pattern.Transform(PatchedBytesPattern);
            var simsBytes = File.ReadAllBytes(c.PathToSims);
            if (Pattern.Find(simsBytes, pattern, out var offset))
            {
                simsBytes[offset + 4] = 0x75;
                File.WriteAllBytes(c.PathToSims, simsBytes);
            }
            else
            {
                throw new Exception($"Couldn't find offset for bytes {PatchedBytesPattern}");
            }
        }

        private const string PatchedBytesPattern = "807B4C00EB43";
    }
}
