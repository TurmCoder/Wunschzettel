using System.Windows;
using StructureMap;

namespace Wunschzettel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            this.InitializeStructeMap();
        }

        private void InitializeStructeMap()
        {
            ObjectFactory.Initialize(o => o.AddRegistry(new ClientRegistry()));
        }
    }
}
