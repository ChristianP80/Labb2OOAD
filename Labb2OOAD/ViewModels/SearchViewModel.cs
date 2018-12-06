using System;
using Labb2OOAD.Validations;

namespace Labb2OOAD.ViewModels
{
    public class SearchViewModel : ExtendedBindableObject
    {
        private ValidatableObject<string> _cityName;

        public SearchViewModel()
        {
            _cityName = new ValidatableObject<string>();
        }

        public ValidatableObject<string> Cityname
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                RaisePropertyChanged(() => Cityname);
            }
        }
    }
}
