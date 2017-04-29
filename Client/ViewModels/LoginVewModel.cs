using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Windows.Controls;
using Client.Annotations;
using Client.Auth;
using Client.Models;

namespace Client.ViewModels
{
    public class LoginVewModel:INotifyPropertyChanged
    {

        public UserCr LoginedUser { get; private set; }

        private readonly IWindowFactory<RegisterViewModel> _registerWindowFactory;
        private readonly IWindowFactory<MainViewModel> _mainWindowFactory;

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public LoginVewModel(IWindowFactory<RegisterViewModel> registerWindowFactory,
            IWindowFactory<MainViewModel> mainWindowFactory)
        {
            _registerWindowFactory = registerWindowFactory;
            _mainWindowFactory = mainWindowFactory;
            LoginedUser = new UserCr();
            LoginedUser.Nickname = "Asd1";
        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(obj =>
                   {
                       var passwordBox = obj as PasswordBox;
                       if (passwordBox != null)
                       {
                           var password = passwordBox.Password;
                           LoginedUser.Password = password;
                           try
                           {
                               SchedulerClient cl = new SchedulerClient();
                               cl.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                               cl.ClientCredentials.UserName.UserName = LoginedUser.Nickname;
                               cl.ClientCredentials.UserName.Password = password;
                               var res = cl.GetUserInformation();
                               LoginedUser.AddInformation(res.CreatedObject);
                               _mainWindowFactory.CreateNewWindow(new MainViewModel(LoginedUser));
                           }
                           catch (Exception ex) when(ex is MessageSecurityException || ex is ArgumentException || ex is FaultException)
                           {
                               ErrorMessage = ex.InnerException?.Message ?? ex.Message;
                           }
                       }
                   }));
            }
        }

        private RelayCommand _inviteCommand;
        public RelayCommand InviteCommand
        {
            get
            {
                return _inviteCommand ?? (_inviteCommand = new RelayCommand(obj =>
                {
                    
                }));
            }
        }




        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ?? (_registerCommand = new RelayCommand(obj =>
                {
                    _registerWindowFactory.CreateNewWindow(new RegisterViewModel());
                }));
            }
        }

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}