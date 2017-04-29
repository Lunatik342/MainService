using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Client.Auth;
using Client.Models;

namespace Client.ViewModels
{
    public class InviteViewModel:INotifyPropertyChanged
    {
        private long _channeId;
        private string _nicknameError;
        private string _inviteStatus;
        private string _nickname;
        private RelayCommand _inviteCommand;
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.Red;
        private UserCr _user;

        public InviteViewModel(UserCr user,long channelId)
        {
            _user = user;
            _channeId = channelId;
        }

        public string Nickname
        {
            get { return _nickname; }
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }

        public string NicknameError
        {
            get { return _nicknameError; }
            set
            {
                _nicknameError = value;
                OnPropertyChanged(nameof(NicknameError));
            }
        }

        public System.Windows.Media.Brush ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                OnPropertyChanged(nameof(ForegroundColor));
            }
        }

        public string InviteStatus
        {
            get { return _inviteStatus; }
            set
            {
                _inviteStatus = value;
                OnPropertyChanged(nameof(InviteStatus));
            }
        }

        public RelayCommand InviteCommand
        {
            get
            {
                return _inviteCommand ?? (_inviteCommand = new RelayCommand(obj =>
                {
                    SchedulerClient cl = new SchedulerClient();
                    cl.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                    cl.ClientCredentials.UserName.UserName = _user.Nickname;
                    cl.ClientCredentials.UserName.Password = _user.Password;
                    var res = cl.InviteUser(Nickname, _channeId);
                    DisplayResult(res);
                }));
            }
        }

        private void DisplayResult(Result regResult)
        {
            if (regResult.ActionResult != ActionResult.Success)
            {
                ForegroundColor = System.Windows.Media.Brushes.Red;
                InviteStatus = regResult.ActionResult.ToString();
                if (regResult.ActionResult == ActionResult.IncorrectParameter)
                {
                    foreach (var error in regResult.Errors)
                    {
                        switch (error.Variable)
                        {
                            case "Nickname":
                                NicknameError = error.CheckStatus.ToString(); break;
                        }
                    }
                }
            }
            else
            {
                ForegroundColor = System.Windows.Media.Brushes.Green;
                InviteStatus = "Invite successful";
                NicknameError = null;
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