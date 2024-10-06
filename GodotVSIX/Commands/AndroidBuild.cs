using System.IO;
using System.Linq;
using System.Text;

namespace GodotVSIX
{
    [Command(PackageIds.AndroidBuid)]
    internal sealed class AndroidBuild : BaseCommand<AndroidBuild>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var s = VS.Solutions.GetCurrentSolution();
            var ps = await VS.Solutions.GetAllProjectsAsync();
            foreach (var project in ps) 
            {
                foreach (var child in project.Children.Where(c => c.Name.Contains(".cs")))
                {
                    string text =  File.ReadAllText(child.FullPath);
                    File.WriteAllText(child.FullPath, text, Encoding.UTF8);
                }
            }
        }
    }
}
