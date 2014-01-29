using System.Windows;
using System.Windows.Data;
using StructureMap;

namespace Wunschzettel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClientServiceConsumer service;

        public MainWindow()
        {
            InitializeComponent();

            this.service = ObjectFactory.GetInstance<IClientServiceConsumer>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var person = this.service.GetPerson(1);
        }
    }
}
