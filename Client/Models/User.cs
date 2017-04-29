using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Client.Auth;

namespace Client.Models
{
    public class User : INotifyPropertyChanged
    {
        long _id;
        string _nickname;
        string _name;
        string _surname;
        string _email;
        string _phone;
        string _group;
        string _description;
        long? _cityId;
        long? _universitId;

        public User()
        {
            
        }

        public User(UserDto u)
        {
            Nickname = u.Nickname;
            Name = u.Name;
            Description = u.Description;
            CityId = u.CityId;
            Email = u.Email;
            Group = u.Group;
            Id = u.Id;
            Phone = u.Phone;
            UniversityId = u.UniversityId;
            Surname = u.Surname;
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
        public string Nickname
        {
            get { return _nickname; }
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
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
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string Group
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
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
        public long? CityId
        {
            get { return _cityId; }
            set
            {
                _cityId = value;
                OnPropertyChanged(nameof(CityId));
            }
        }
        public long? UniversityId
        {
            get { return _universitId; }
            set
            {
                _universitId = value;
                OnPropertyChanged(nameof(UniversityId));
            }
        }

        public void AddInformation(UserDto u)
        {
            Name = u.Name;
            Description = u.Description;
            CityId = u.CityId;
            Email = u.Email;
            Group = u.Group;
            Id = u.Id;
            Phone = u.Phone;
            UniversityId = u.UniversityId;
            Surname = u.Surname;
        }

        public static ObservableCollection<User> Convert(UserDto[] users)
        {
            return new ObservableCollection<User>(users.Select(u=>new User(u)));
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

    public class UserCr : User
    {
        string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }


}