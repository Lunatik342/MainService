
using Client.ViewModels;
using Client.Views;

namespace Client
{
    public interface IWindowFactory<T>
    {
        void CreateNewWindow(T viewModel);
    }

    public class RegisterWindowFactory : IWindowFactory<RegisterViewModel>
    {
        public void CreateNewWindow(RegisterViewModel regViewModel)
        {
            var window = new RegisterWindow
            {
                DataContext = regViewModel
            };
            window.ShowDialog();
        }
        
    }


    public class MainWindowFactory : IWindowFactory<MainViewModel>
    {
        public void CreateNewWindow(MainViewModel maindViewModel)
        {
            var window = new MainWindow
            {
                DataContext = maindViewModel
            };
            window.ShowDialog();
        }

    }


    public class ChannelCreationWindowFactory : IWindowFactory<ChannelCreationViewModel>
    {
        public void CreateNewWindow(ChannelCreationViewModel channelViewModel)
        {
            var window = new ChannelCreationWindow
            {
                DataContext = channelViewModel
            };
            window.ShowDialog();
        }

    }

    public class InviteWindowFactory : IWindowFactory<InviteViewModel>
    {
        public void CreateNewWindow(InviteViewModel inviteViewModel)
        {
            var window = new InviteWindow
            {
                DataContext = inviteViewModel
            };
            window.ShowDialog();
        }

    }
    
    public class EventCreationWindowFactory : IWindowFactory<EventCreationViewModel>
    {
        public void CreateNewWindow(EventCreationViewModel eventCreationViewModel)
        {
            var window = new EventCreationWindow
            {
                DataContext = eventCreationViewModel
            };
            window.ShowDialog();
        }

    }

}
