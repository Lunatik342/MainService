using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Client.NonAuth;

namespace Client.Models
{
    public class UniversityModel
    {
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                _shortName = value;
                OnPropertyChanged(nameof(ShortName));
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
            return ShortName;
        }

        public static UniversityModel Convert(UniversityDto cityDto)
        {
            var university = new UniversityModel
            {
                ShortName = cityDto.ShortName,
                Id = cityDto.Id
            };
            return university;
        }

        public static ObservableCollection<UniversityModel> Convert(UniversityDto[] cityDtos)
        {
            var universities = new ObservableCollection<UniversityModel>();
            foreach (var universityDto in cityDtos)
            {
                universities.Add(UniversityModel.Convert(universityDto));
            }
            return universities;
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