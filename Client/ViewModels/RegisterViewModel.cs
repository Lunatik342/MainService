using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Client.Annotations;
using Client.Models;
using Client.NonAuth;
using ActionResult = Client.NonAuth.ActionResult;
using UserCrDto = Client.NonAuth.UserCrDto;

namespace Client.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<City> _cities;
        private ObservableCollection<UniversityModel> _universities;
        private string _univerSearchText;
        private string _registrationStatus;
        private UserCrDto _userCreationDto = new UserCrDto();
        private UniversityModel _selectedUniversity = new UniversityModel();
        private City _selectedCity = new City();
        private RegistrationErrors _regitrationErrors = new RegistrationErrors();
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.Red;

        private RelayCommand _universitiesCommand;
        private RelayCommand _registerCommand;

        private NoValidationServiceClient _client;

        public RegisterViewModel()
        {
            _client = new NoValidationServiceClient();
            _client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            var res = _client.GetCities();
            _cities = new ObservableCollection<City>(City.Convert(res));

        }

        public UniversityModel SelectedUnivercity
        {
            get { return _selectedUniversity; }
            set
            {
                _selectedUniversity = value;
                if (SelectedUnivercity != null)
                    _userCreationDto.UniversityId = SelectedUnivercity.Id;
                else
                {
                    _userCreationDto.UniversityId = null;
                }
                OnPropertyChanged(nameof(UserCreationDto));
            }
        }

        public RegistrationErrors Errors
        {
            get { return _regitrationErrors; }
            set
            {
                _regitrationErrors = value;
                OnPropertyChanged(nameof(Errors));
            }
        }


        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                if (_selectedCity != null)
                    _userCreationDto.CityId = value.Id;
                else
                {
                    _userCreationDto.CityId = null;
                }
                OnPropertyChanged(nameof(UserCreationDto));
            }
        }

        public UserCrDto UserCreationDto
        {
            get { return _userCreationDto; }
            set
            {
                _userCreationDto = value;
                OnPropertyChanged(nameof(UserCreationDto));
            }
        }

        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(Universities));
            }
        }

        public string UniverSearchText
        {
            get { return _univerSearchText; }
            set
            {
                _univerSearchText = value;
                if (UniversitiesCommand.CanExecute(this))
                    UniversitiesCommand.Execute(this);
            }
        }

        public ObservableCollection<UniversityModel> Universities
        {
            get { return _universities; }
            set
            {
                _universities = value;
                OnPropertyChanged(nameof(Universities));
            }
        }

        public string RegisterStatus
        {
            get { return _registrationStatus; }
            set
            {
                _registrationStatus = value;
                OnPropertyChanged(nameof(RegisterStatus));
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

        public RelayCommand UniversitiesCommand
        {
            get
            {
                return _universitiesCommand ?? (_universitiesCommand = new RelayCommand(obj =>
                {

                    if (string.IsNullOrWhiteSpace(_univerSearchText))
                        return;
                    var res = _client.GetUnivercities(_univerSearchText);
                    Universities = UniversityModel.Convert(res);
                }));
            }
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ?? (_registerCommand = new RelayCommand(obj =>
                {
                    var passwordBox = obj as PasswordBox;
                    if (passwordBox != null)
                        UserCreationDto.Password = passwordBox.Password;
                    var regResult = _client.Register(UserCreationDto);
                    DisplayResult(regResult);
                }));
            }
        }

        private void DisplayResult(CrResultOfUserDtoGvCn2ESm regResult)
        {
            if (regResult.ActionResult != ActionResult.Success)
            {
                ForegroundColor = System.Windows.Media.Brushes.Red;
                RegisterStatus = regResult.ActionResult.ToString();
                if (regResult.ActionResult == ActionResult.IncorrectParameter)
                {
                    foreach (var error in regResult.Errors)
                    {
                        switch (error.Variable)
                        {
                            case "Nickname":
                                Errors.NicknameError = error.CheckStatus.ToString(); break;
                            case "Password":
                                Errors.PasswordError = error.CheckStatus.ToString(); break;
                            case "Email":
                                Errors.EmailError = error.CheckStatus.ToString(); break;
                            case "Phone":
                                Errors.PhoneError = error.CheckStatus.ToString(); break;
                            case "Description":
                                Errors.DescriptionError = error.CheckStatus.ToString(); break;
                            case "Group":
                                Errors.GroupError = error.CheckStatus.ToString(); break;
                            case "Name":
                                Errors.NameError = error.CheckStatus.ToString(); break;
                            case "Surname":
                                Errors.SurnameError = error.CheckStatus.ToString(); break;
                        }
                    }
                } 
            }
            else
            {
                ForegroundColor = System.Windows.Media.Brushes.Green;
                RegisterStatus = "Registration successful";
                Errors = new RegistrationErrors();
            }
        }



        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
}