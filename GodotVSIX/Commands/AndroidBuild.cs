using Microsoft.VisualStudio.Shell.Interop;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace GodotVSIX
{
    [Command(PackageIds.AndroidBuid)]
    internal sealed class AndroidBuild : BaseCommand<AndroidBuild>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var workDic = Path.GetDirectoryName( VS.Solutions.GetCurrentSolution().FullPath);
            var apk = Directory.GetFiles(workDic).Where(f => f.Contains(".apk")).Single();

        }
    }
}
