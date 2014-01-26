using System.Windows;

namespace Wunschzettel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IClientServiceConsumer service;

        public App(IClientServiceConsumer service)
        {
            this.service = service;
        }
    }
}
