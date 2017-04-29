using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Annotations;

namespace Client.Models
{
    public class RegistrationErrors:INotifyPropertyChanged
    {
        private string _nicknameError;
        public string NicknameError
        {
            get { return _nicknameError; }
            set
            {
                _nicknameError = value;
                OnPropertyChanged(nameof(NicknameError));
            }
        }

        private string _passwordError;
        public string PasswordError
        {
            get { return _passwordError; }
            set
            {
                _passwordError = value;
                OnPropertyChanged(nameof(PasswordError));
            }
        }

        private string _nameError;
        public string NameError
        {
            get { return _nameError; }
            set
            {
                _nameError = value;
                OnPropertyChanged(nameof(NameError));
            }
        }


        private string _surnameError;
        public string SurnameError
        {
            get { return _surnameError; }
            set
            {
                _surnameError = value;
                OnPropertyChanged(nameof(SurnameError));
            }
        }

        private string _emailError;
        public string EmailError
        {
            get { return _emailError; }
            set
            {
                _emailError = value;
                OnPropertyChanged(nameof(EmailError));
            }
        }


        private string _phoneError;
        public string PhoneError
        {
            get { return _phoneError; }
            set
            {
                _phoneError = value;
                OnPropertyChanged(nameof(PhoneError));
            }
        }

        private string _groupError;
        public string GroupError
        {
            get { return _groupError; }
            set
            {
                _groupError = value;
                OnPropertyChanged(nameof(GroupError));
            }
        }


        private string _descriptionError;
        public string DescriptionError
        {
            get { return _descriptionError; }
            set
            {
                _descriptionError = value;
                OnPropertyChanged(nameof(DescriptionError));
            }
        }

        private string _cityError;
        public string CityError
        {
            get { return _cityError; }
            set
            {
                _cityError = value;
                OnPropertyChanged(nameof(CityError));
            }
        }


        private string _univercityError;
        public string UnivercityError
        {
            get { return _univercityError; }
            set
            {
                _univercityError = value;
                OnPropertyChanged(nameof(UnivercityError));
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




    public class EventErrors : INotifyPropertyChanged
    {
        private string _titleError;
        public string TitleError
        {
            get { return _titleError; }
            set
            {
                _titleError = value;
                OnPropertyChanged(nameof(TitleError));
            }
        }

        private string _descriptionError;
        public string DescriptionError
        {
            get { return _descriptionError; }
            set
            {
                _descriptionError = value;
                OnPropertyChanged(nameof(DescriptionError));
            }
        }

        private string _eventTimeError;
        public string EventTimeError
        {
            get { return _eventTimeError; }
            set
            {
                _eventTimeError = value;
                OnPropertyChanged(nameof(EventTimeError));
            }
        }


        private string _importanceError;
        public string ImportanceError
        {
            get { return _importanceError; }
            set
            {
                _importanceError = value;
                OnPropertyChanged(nameof(ImportanceError));
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