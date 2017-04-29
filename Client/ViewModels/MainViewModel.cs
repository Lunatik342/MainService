using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Annotations;
using Client.Auth;
using Client.Models;
using Client.NonAuth;
using ActionResult = Client.Auth.ActionResult;

namespace Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChannelInfo> _channelsInfo;
        private ChannelInfo _selectedChannelInfo;

        private string _stateMessage;
        private System.Windows.Media.Brush _stateMessageColor = System.Windows.Media.Brushes.Red;


        private RelayCommand _createChannelCommand;
        private RelayCommand _inviteUserCommand;
        private RelayCommand _deleteChannelCommand;
        private RelayCommand _createEventCommand;
        private RelayCommand _leaveChannelCommand;
        private NoValidationServiceClient _noValidationClient;
        private UserCr _user;

        public MainViewModel(UserCr user)
        {
            _user = user;
            var clientFactory = new ClientFacrory();
            Client = clientFactory.CreateSchedulerClient(user);
            _noValidationClient = clientFactory.CreateNoValidationClient();
            ImportanceScale = new ObservableCollection<ImportanceDto>(_noValidationClient.GetImportanceScale());
            RolePermitions = new ObservableCollection<RolePermitions>(_noValidationClient.GetRolePermitions());
            var res = Client.GetChannels();
            ChannelsInfo = ChannelInfo.Convert(res.CreatedObject,this);
        }

        public SchedulerClient Client { get;private set; }

        public ObservableCollection<ImportanceDto> ImportanceScale { get; private set; }

        public ObservableCollection<RolePermitions> RolePermitions { get; private set; }

        public string StateMessage
        {
            get { return _stateMessage; }
            set
            {
                _stateMessage = value;
                OnPropertyChanged(nameof(StateMessage));

            }
        }
        public System.Windows.Media.Brush StateMessageColor
        {
            get { return _stateMessageColor; }
            set
            {
                _stateMessageColor = value;
                OnPropertyChanged(nameof(StateMessageColor));
            }
        }

        public ObservableCollection<ChannelInfo> ChannelsInfo
        {
            get { return _channelsInfo; }
            set
            {
                _channelsInfo = value;
                OnPropertyChanged(nameof(ChannelsInfo));
            }
        }


        public ChannelInfo SelectedChannelInfo
        {
            get { return _selectedChannelInfo; }
            set
            {
                _selectedChannelInfo = value;
                if (SelectedChannelInfo != null)
                    _selectedChannelInfo.SetEvents();
                OnPropertyChanged(nameof(SelectedChannelInfo));

            }
        }


        public RelayCommand CreateChannelCommand///////////////////////////////////////////
        {
            get
            {
                return _createChannelCommand ?? (_createChannelCommand = new RelayCommand(obj =>
                {
                    var channelCreationWindowFactory = new ChannelCreationWindowFactory();
                    channelCreationWindowFactory.CreateNewWindow(new ChannelCreationViewModel(ChannelsInfo, Client, RolePermitions, ImportanceScale));
                }));
            }
        }

        public RelayCommand InviteUserCommand///////////////////////////////////////////
        {
            get
            {
                return _inviteUserCommand ?? (_inviteUserCommand = new RelayCommand(obj =>
                {
                    var inviteWindowFactory = new InviteWindowFactory();
                    if (SelectedChannelInfo != null)
                        inviteWindowFactory.CreateNewWindow(new InviteViewModel(_user, SelectedChannelInfo.Channel.Id));/////////////////////
                }));
            }
        }

        public RelayCommand DeleteChannelCommand/////////////////////////////////////////
        {
            get
            {
                string actionMessage = "Delete channel: ";
                return _deleteChannelCommand ?? (_deleteChannelCommand = new RelayCommand(obj =>
                {
                    if (SelectedChannelInfo != null)
                    {
                        var mbRes = MessageBox.Show("Are you sure you want to delete this channel?",
                            "Delete \"" + SelectedChannelInfo.Channel.Name + "\" channel", MessageBoxButton.YesNo,
                            MessageBoxImage.Question);
                        if (mbRes == MessageBoxResult.Yes)
                        {
                            var res = Client.DeleteChannel(SelectedChannelInfo.Channel.Id);
                            if (res.ActionResult == ActionResult.Success)
                            {
                                ShowSuccessMessage(actionMessage + res.ActionResult);
                                ChannelsInfo.Remove(SelectedChannelInfo);
                            }
                            else
                            {
                                ShowErrorMessage(actionMessage + res.ActionResult);
                            }
                        }
                    }
                }));
            }
        }

        public RelayCommand CreateEventCommand////////////////////////////////////////////////
        {
            get
            {
                return _createEventCommand ?? (_createEventCommand = new RelayCommand(obj =>
                {
                    if (SelectedChannelInfo != null)
                    {
                        var fac = new EventCreationWindowFactory();
                        fac.CreateNewWindow(new EventCreationViewModel(SelectedChannelInfo.Channel.Id, ImportanceScale, Client));///////////////////
                    }
                }));
            }
        }

        public RelayCommand LeaveChannelCommand////////////////////////////////////////////////
        {
            get
            {
                return _leaveChannelCommand ?? (_leaveChannelCommand = new RelayCommand(obj =>
                {
                    string actionMessage = "Leave channel: ";
                    if (SelectedChannelInfo != null)
                    {
                        var mbRes = MessageBox.Show("Are you sure you want to leave this channel?",
                            "Leave \"" + SelectedChannelInfo.Channel.Name + "\" channel", MessageBoxButton.YesNo,
                            MessageBoxImage.Question);

                        if (mbRes == MessageBoxResult.Yes)
                        {
                            var res = Client.LeaveChannel(SelectedChannelInfo.Channel.Id);
                            if (res.ActionResult == ActionResult.Success)
                            {
                                ShowSuccessMessage(actionMessage + res.ActionResult);
                                ChannelsInfo.Remove(SelectedChannelInfo);
                            }
                            else
                            {
                                ShowErrorMessage(actionMessage + res.ActionResult);
                            }
                        }

                    }
                }));
            }
        }

        public void ShowErrorMessage(string text)
        {
            StateMessageColor = System.Windows.Media.Brushes.Red;
            SetMessage(text);
        }

        public void ShowSuccessMessage(string text)
        {
            StateMessageColor = System.Windows.Media.Brushes.Green;
            SetMessage(text);
        }

        void SetMessage(string text)
        {
            StateMessage = text;
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
