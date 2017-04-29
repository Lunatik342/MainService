using System.Windows;
using SchedulerClient.ViewModels;

namespace SchedulerClient.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new UserCredentialsVewModel();
        }
    }
}
