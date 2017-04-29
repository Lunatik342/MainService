using System.Windows;
using Client.ViewModels;

namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginVewModel(new RegisterWindowFactory(),new MainWindowFactory());
        }
    }
}
