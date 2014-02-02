using System.Windows;
using StructureMap;

namespace Wunschzettel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IClientServiceConsumer service;

        protected override void OnStartup(StartupEventArgs e)
        {
            this.Initalization();

            base.OnStartup(e);

            this.Start();
        }

        private void Initalization()
        {
            this.InitializeStructeMap();

            this.InitializeInterfaceFields();
        }

        private void InitializeInterfaceFields()
        {
            this.service = ObjectFactory.GetInstance<IClientServiceConsumer>();
        }

        private void Start()
        {
            this.ShowLoginScreen();

            this.ShowMainWindow();
        }

        private void ShowLoginScreen()
        {
                
        }

        private void ShowMainWindow()
        {
            var mainWindow = new MainWindow(this.service);

            mainWindow.Show();
        }

        private void InitializeStructeMap()
        {
            ObjectFactory.Initialize(o => o.AddRegistry(new ClientRegistry()));
        }
    }
}
