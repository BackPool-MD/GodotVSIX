using System.IO;
using System.Linq;
using System.Text;

namespace GodotVSIX
{
    [Command(PackageIds.UTF8Command)]
    internal sealed class UTF8Files : BaseCommand<UTF8Files>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var allProject = await VS.Solutions.GetAllProjectsAsync();
            foreach (var project in allProject) 
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
