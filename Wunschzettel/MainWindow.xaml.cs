using System.Windows;

namespace Wunschzettel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClientServiceConsumer service;

        public MainWindow(IClientServiceConsumer service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
