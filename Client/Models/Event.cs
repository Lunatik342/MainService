using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using Client.Annotations;
using Client.Auth;
using Client.NonAuth;
using Client.ViewModels;
using ActionResult = Client.Auth.ActionResult;

namespace Client.Models
{
    public class Event : INotifyPropertyChanged
    {
        private long _id;
        private string _title;
        private string _description;
        private ImportanceDto _importance;
        private DateTime _eventDateTime;
        private DateTime _creationDateTime;
        private Brush _importanceColor;
        private MainViewModel _mainViewModel;

        public Event(long id, string title, string description, DateTime evDateTime, ImportanceDto importance)
        {
            EventDateTime = evDateTime;
            Id = id;
            Title = title;
            Description = description;
            Importance = importance;
        }

        private RelayCommand _deleteEvent;
        public RelayCommand DeleteEvent
        {
            get
            {
                return _deleteEvent ?? (_deleteEvent = new RelayCommand(obj =>
                {
                    string action = "Delete event: ";
                    var ev = obj as Event;
                    if (ev != null)
                    {
                        var res = _mainViewModel.Client.DeleteEvent(ev.Id);
                        if (res.ActionResult == ActionResult.Success)
                        {
                            _mainViewModel.ShowSuccessMessage(action + "success");
                            _mainViewModel.SelectedChannelInfo.Events.Remove(ev);
                        }
                        else
                        {
                            _mainViewModel.ShowSuccessMessage(action + res.ActionResult);
                        }
                    }
                }));
            }
        }

        public Event(EventDto eventDto, MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            Id = eventDto.EventId;
            Title = eventDto.Title;
            Description = eventDto.Description;
            EventDateTime = eventDto.EventTime;
            CreationDateTime = eventDto.CreationTime;
            if (eventDto.ImportanceId != null)
                Importance = mainViewModel.ImportanceScale.First(imp => imp.ImportanceId == eventDto.ImportanceId);
            else
            {
                Importance = null;
            }
        }

        public Brush ImportanceColor
        {
            get { return _importanceColor; }
            set
            {
                _importanceColor = value;
                OnPropertyChanged(nameof(ImportanceColor));
            }
        }

        private Brush ConvertToColor()
        {
            if (Importance == null)
                return Brushes.Gray;
            if (Importance.ImportanceId == 0)
                return Brushes.Blue;
            if (Importance.ImportanceId == 1)
                return Brushes.Green;
            if (Importance.ImportanceId == 2)
                return Brushes.Yellow;
            if (Importance.ImportanceId == 3)
                return Brushes.Orange;
            if (Importance.ImportanceId == 4)
                return Brushes.Red;
            return Brushes.Gray;

        }


        public DateTime EventDateTime
        {
            get { return _eventDateTime; }
            set
            {
                _eventDateTime = value;
                OnPropertyChanged(nameof(EventDateTime));
            }
        }

        public DateTime CreationDateTime
        {
            get { return _creationDateTime; }
            set
            {
                _creationDateTime = value;
                OnPropertyChanged(nameof(CreationDateTime));
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

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
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

        public ImportanceDto Importance
        {
            get { return _importance; }
            set
            {
                _importance = value;
                ImportanceColor = ConvertToColor();
                OnPropertyChanged(nameof(Importance));
            }
        }

        public static ObservableCollection<Event> Convert(EventDto[] events, MainViewModel mainViewModel)
        {
            return new ObservableCollection<Event>(events.Select(ev => new Event(ev, mainViewModel)));
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