using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Client.NonAuth;

namespace Client.Models
{
    public class Role:INotifyPropertyChanged
    {
        private long _id;
        private string _name;
        private Permissions _permissions;

        public Role(long roleId,string roleName,IEnumerable<RolePermitions> rolePermitions)
        {
            Id = roleId;
            _name = roleName;
            _permissions = new Permissions(roleId, rolePermitions);
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
        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Permissions RolePermissons
        {
            get { return _permissions; }
            set
            {
                _permissions = value;
                OnPropertyChanged(nameof(RolePermissons));
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