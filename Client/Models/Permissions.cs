using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Client.NonAuth;

namespace Client.Models
{
    public class Permissions:INotifyPropertyChanged
    {
        private bool _deleteChannelAllowed;
        private bool _addUserAllowed;
        private bool _addNewsAllowed;
        private bool _deleteUsersAllowed;
        private bool _deleteNewsAllowed;
        private bool _changeRolesAllowed;
        private bool _editNewsAllowed;
        private bool _readNewsAllowed;
        private bool _viewMembersAllowed;

        public Permissions(long roleId,IEnumerable<RolePermitions> rolesPermitions)
        {
            var myRole = rolesPermitions.First(roleP => roleP.RoleId == roleId);
            foreach (var rolePermitions in myRole.Permitions)
            {
                switch (rolePermitions.RermitionId)
                {
                    case 1:
                        DeleteChannelAllowed = true;break;
                    case 2:
                        AddUserAllowed = true; break;
                    case 3:
                        AddNewsAllowed = true; break;
                    case 4:
                        DeleteUsersAllowed = true; break;
                    case 5:
                        DeleteNewsAllowed = true; break;
                    case 6:
                        ChangeRolesAllowed = true; break;
                    case 7:
                        EditNewsAllowed = true; break;
                    case 8:
                        ReadNewsAllowed = true; break;
                    case 10:
                        ViewMembersAllowed = true; break;
                }
            }
        }

       
        public bool DeleteChannelAllowed
        {
            get { return _deleteChannelAllowed; }
            set
            {
                _deleteChannelAllowed = value;
                OnPropertyChanged(nameof(DeleteChannelAllowed));
            }
        }

        
        public bool AddUserAllowed
        {
            get { return _addUserAllowed; }
            private set
            {
                _addUserAllowed = value;
                OnPropertyChanged(nameof(AddUserAllowed));
            }
        }
        
        public bool AddNewsAllowed
        {
            get { return _addNewsAllowed; }
            private set
            {
                _addNewsAllowed = value;
                OnPropertyChanged(nameof(AddNewsAllowed));
            }
        }

        
        public bool DeleteUsersAllowed
        {
            get { return _deleteUsersAllowed; }
            private set
            {
                _deleteUsersAllowed = value;
                OnPropertyChanged(nameof(DeleteUsersAllowed));
            }
        }

        
        public bool DeleteNewsAllowed
        {
            get { return _deleteNewsAllowed; }
            private set
            {
                _deleteNewsAllowed = value;
                OnPropertyChanged(nameof(DeleteNewsAllowed));
            }
        }

        
        public bool ChangeRolesAllowed
        {
            get { return _changeRolesAllowed; }
            private set
            {
                _changeRolesAllowed = value;
                OnPropertyChanged(nameof(ChangeRolesAllowed));
            }
        }

        
        public bool EditNewsAllowed
        {
            get { return _editNewsAllowed; }
            private set
            {
                _editNewsAllowed = value;
                OnPropertyChanged(nameof(EditNewsAllowed));
            }
        }

        public bool ReadNewsAllowed
        {
            get { return _readNewsAllowed; }
            private set
            {
                _readNewsAllowed = value;
                OnPropertyChanged(nameof(ReadNewsAllowed));
            }
        }

        public bool ViewMembersAllowed
        {
            get { return _viewMembersAllowed; }
            private set
            {
                _viewMembersAllowed = value;
                OnPropertyChanged(nameof(ViewMembersAllowed));
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
}