using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using Client.Annotations;
using Client.NonAuth;

namespace Client.Models
{
    public class City : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private long _id;
        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public static City Convert(CityDto cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
                Id = cityDto.Id
            };
            return city;
        }

        public static ObservableCollection<City> Convert(CityDto[] cityDtos)
        {
            var cityObserverableColl = new ObservableCollection<City>();
            foreach (var cityDto in cityDtos)
            {
                cityObserverableColl.Add(City.Convert(cityDto));
            }
            return cityObserverableColl;
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