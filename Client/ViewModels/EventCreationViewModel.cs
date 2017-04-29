using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Client.Annotations;
using Client.Auth;
using Client.Models;
using Client.NonAuth;
using ActionResult = Client.NonAuth.ActionResult;

namespace Client.ViewModels
{
    public class EventCreationViewModel : INotifyPropertyChanged
    {
        private string _actionResult;
        private EventErrors _errors;
        private EventCrDto _event;
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.Red;
        private RelayCommand _createEventCommand;
        private ObservableCollection<ImportanceDto> _importanceScale;
        private ImportanceDto _selectedImportance;

        private readonly SchedulerClient _client;

        public EventCreationViewModel(long channelId,ObservableCollection<ImportanceDto> importanceScale,SchedulerClient client)
        {
            _client = client;
            _importanceScale = importanceScale;
            _errors = new EventErrors();
            _event = new EventCrDto();
            _event.EventTime = DateTime.Now;
            _event.ChannelId = channelId;
        }

        public ObservableCollection<ImportanceDto> ImportanceScale
        {
            get { return _importanceScale; }
            set
            {
                _importanceScale = value;
                OnPropertyChanged(nameof(Errors));
            }
        }

        public EventErrors Errors
        {
            get { return _errors; }
            set
            {
                _errors = value;
                OnPropertyChanged(nameof(Errors));
            }
        }

        public EventCrDto Event
        {
            get { return _event; }
            set
            {
                _event = value;
                OnPropertyChanged(nameof(Event));
            }
        }

        public ImportanceDto SelectedImportance
        {
            get { return _selectedImportance; }
            set
            {
                _selectedImportance = value;
                OnPropertyChanged(nameof(SelectedImportance));
            }
        }

        public string ActionResult
        {
            get { return _actionResult; }
            set
            {
                _actionResult = value;
                OnPropertyChanged(nameof(ActionResult));
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

        public RelayCommand CreateEventCommand
        {
            get
            {
                return _createEventCommand ?? (_createEventCommand = new RelayCommand(obj =>
                {
                    if(SelectedImportance!=null)
                        _event.ImportanceId = SelectedImportance.ImportanceId;
                    var regResult = _client.CreateEvent(_event);
                    var res2 =_client.EditEvent(_event);
                    DisplayResult(regResult);
                }));
            }
        }

        private void DisplayResult(CrResultOfEventDtoGvCn2ESm res)
        {
            if (res.ActionResult != Auth.ActionResult.Success)
            {
                ForegroundColor = System.Windows.Media.Brushes.Red;
                ActionResult = res.ActionResult.ToString();
                if (res.ActionResult == Auth.ActionResult.IncorrectParameter)
                {
                    foreach (var error in res.Errors)
                    {
                        switch (error.Variable)
                        {
                            case "Title":
                                Errors.TitleError = error.CheckStatus.ToString(); break;
                            case "Description":
                                Errors.DescriptionError = error.CheckStatus.ToString(); break;
                            case "EventTime":
                                Errors.EventTimeError = error.CheckStatus.ToString(); break;
                            case "Importance":
                                Errors.ImportanceError = error.CheckStatus.ToString(); break;
                            default: Errors.ImportanceError = error.CheckStatus.ToString(); break;
                        }
                    }
                }
            }
            else
            {
                ForegroundColor = System.Windows.Media.Brushes.Green;
                ActionResult = "Creation successful";
                Errors = new EventErrors();
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