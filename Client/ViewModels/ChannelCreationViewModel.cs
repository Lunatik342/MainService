using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Client.Auth;
using Client.Models;
using Client.NonAuth;
using ActionResult = Client.Auth.ActionResult;

namespace Client.ViewModels
{
    public class ChannelCreationViewModel:INotifyPropertyChanged
    {
        private ChannelCrDto _channelCreationDto;
        private string _nameError;
        private SchedulerClient _cl;
        private string _descriptionError;
        private string _registrationStatus;
        private RelayCommand _createCommand;
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.Red;
        private readonly ObservableCollection<ChannelInfo> _channels;
        private readonly IEnumerable<RolePermitions> _rolesPermitions;
        private readonly IEnumerable<ImportanceDto> _importanceDtos;

        public ChannelCreationViewModel(ObservableCollection<ChannelInfo> channels, SchedulerClient cl,
            IEnumerable<RolePermitions> rolesPermitions, IEnumerable<ImportanceDto> importanceDtos)
        {
            _cl = cl;
            this._rolesPermitions = rolesPermitions;
            this._importanceDtos = importanceDtos;
            _channelCreationDto = new ChannelCrDto();
            _channels = channels;
        }

        public ChannelCrDto ChannelCreationDto {
            get { return _channelCreationDto; }
            set
            {
                _channelCreationDto = value;
                OnPropertyChanged(nameof(ChannelCreationDto));
            }
        }

        public string NameError
        {
            get { return _nameError; }
            set
            {
                _nameError = value;
                OnPropertyChanged(nameof(NameError));
            }
        }

        public string DescriptionError
        {
            get { return _descriptionError; }
            set
            {
                _descriptionError = value;
                OnPropertyChanged(nameof(DescriptionError));
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

        public string RegisterStatus
        {
            get { return _registrationStatus; }
            set
            {
                _registrationStatus = value;
                OnPropertyChanged(nameof(RegisterStatus));
            }
        }

        public RelayCommand CreateCommand
        {
            get
            {
                return _createCommand ?? (_createCommand = new RelayCommand(obj =>
                {
                    var res = _cl.CreateChannel(ChannelCreationDto);
                    DisplayResult(res);
                }));
            }
        }

        private void DisplayResult(CrResultOfChannelRoleDtoGvCn2ESm crResult)
        {
            if (crResult.ActionResult != ActionResult.Success)
            {
                ForegroundColor = System.Windows.Media.Brushes.Red;
                RegisterStatus = crResult.ActionResult.ToString();
                if (crResult.ActionResult == ActionResult.IncorrectParameter)
                {
                    foreach (var error in crResult.Errors)
                    {
                        switch (error.Variable)
                        {
                            case "Name":
                                NameError = error.CheckStatus.ToString(); break;
                            case "Description":
                                DescriptionError = error.CheckStatus.ToString(); break;
                        }
                    }
                }
            }
            else
            {
                //_channels.Add(new ChannelInfo(crResult.CreatedObject,this));
                ForegroundColor = System.Windows.Media.Brushes.Green;
                RegisterStatus = "Creation successful";
                NameError = null;
                DescriptionError = null;
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