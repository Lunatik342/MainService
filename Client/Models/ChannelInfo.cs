using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Client.Annotations;
using Client.Auth;
using Client.NonAuth;
using Client.ViewModels;
using ActionResult = Client.Auth.ActionResult;

namespace Client.Models
{
    public class ChannelInfo : INotifyPropertyChanged
    {
        private Channel _channel;
        private ObservableCollection<Event> _events;
        private ObservableCollection<User> _users;
        private MainViewModel _mainViewModel;

        public ChannelInfo(ChannelRoleDto channelRole, MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _channel = new Channel(channelRole, mainViewModel.RolePermitions);
        }


        public static ObservableCollection<ChannelInfo> Convert(ChannelRoleDto[] channelRole, MainViewModel mainVM)
        {
            return new ObservableCollection<ChannelInfo>(channelRole.Select(chRole
                => new ChannelInfo(chRole, mainVM)));
        }

        public Channel Channel
        {
            get { return _channel; }
            set
            {
                _channel = value;
                OnPropertyChanged(nameof(Channel));
            }
        }

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            private set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            private set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public bool SetUsers()
        {
            if (_channel.ChannelRole.RolePermissons.ViewMembersAllowed)
            {
                var res = _mainViewModel.Client.GetChannelsUsers(_channel.Id);
                if (res.ActionResult == ActionResult.Success)
                {
                    Users = User.Convert(res.CreatedObject);
                    return true;
                }
            }
            return false;
        }


        public void SetEvents()
        {
            if (_channel.ChannelRole.RolePermissons.ReadNewsAllowed)
            {
                var res = _mainViewModel.Client.GetEvents(10,0,DateTime.Now, _channel.Id);
                if (res.ActionResult == ActionResult.Success)
                    Events = Event.Convert(res.CreatedObject, _mainViewModel);
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