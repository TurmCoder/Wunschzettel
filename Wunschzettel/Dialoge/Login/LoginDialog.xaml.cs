using System.Windows;

namespace Wunschzettel.Dialoge.Login
{
    /// <summary>
    /// Interaktionslogik f�r LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        private readonly ILoginHelper loginHelper;

        public LoginDialog(ILoginHelper loginHelper)
        {
            this.loginHelper = loginHelper;

            InitializeComponent();
        }
    }
}
