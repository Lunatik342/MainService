using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Client.Annotations;
using Client.Auth;
using Client.NonAuth;

namespace Client.Models
{
    public class ChannelCr : INotifyPropertyChanged
    {
        private string _name;
        private string _description;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        #region MyRegion
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class Channel : ChannelCr
    {
        private Role _role;
        private long _id;

        public Role ChannelRole
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(ChannelRole));
            }
        }

        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public Channel(ChannelRoleDto channelRoleDto, IEnumerable<RolePermitions> rolePermitions)
        {
            Id = channelRoleDto.ChannelId;
            Name = channelRoleDto.Name;
            Description = channelRoleDto.Description;
            ChannelRole = new Role(channelRoleDto.RoleId, channelRoleDto.RoleName, rolePermitions);
        }

        public static ObservableCollection<Channel> Convert(ChannelRoleDto[] channels, 
            IEnumerable<RolePermitions> rolePermitions)
        {
            var res = new ObservableCollection<Channel>();
            foreach (var channelDto in channels)
            {
                res.Add(new Channel(channelDto, rolePermitions));
            }
            return res;
        }

    }
}