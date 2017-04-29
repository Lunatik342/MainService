using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;

namespace SchedulerClient.Models
{
    
    public class UserCredentials : INotifyPropertyChanged
    {
        private string _nickname;
        private SecureString _password;

        public string Nickname
        {
            get { return _nickname; }
            set
            {
                _nickname = value;
                OnPropertyChanged("Nickname");
            }
        }
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

}