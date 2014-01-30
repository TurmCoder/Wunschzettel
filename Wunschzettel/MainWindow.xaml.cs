using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using StructureMap;
using Wunschzettel.ViewModel;

namespace Wunschzettel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClientServiceConsumer service;
        private CollectionViewSource personViewModelViewSource;

        public MainWindow()
        {
            InitializeComponent();

            this.service = ObjectFactory.GetInstance<IClientServiceConsumer>();
        }

      
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            this.personViewModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // personViewModelViewSource.Source = [generic data source]
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var person = this.service.GetPerson(1);
            var pvm = new PersonViewModel(person);
            var bindinglist = new BindingList<PersonViewModel>();
            bindinglist.Add(pvm);
            this.personViewModelViewSource.Source = bindinglist;
        }
    }
}
