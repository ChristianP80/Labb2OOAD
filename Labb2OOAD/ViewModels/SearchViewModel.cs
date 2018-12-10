using System;
using System.Windows.Input;
using Labb2OOAD.Validations;
using Xamarin.Forms;

namespace Labb2OOAD.ViewModels
{
    public class SearchViewModel : ExtendedBindableObject
    {
        public ICommand ValidateCityNameCommand => new Command(() => ValidateCityName());

        private ValidatableObject<string> _cityName;

        public ValidatableObject<string> Cityname
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                RaisePropertyChanged(() => Cityname);
            }
        }

        public SearchViewModel()
        {
            _cityName = new ValidatableObject<string>();
            AddValidations();
        }

        private void AddValidations()
        {
            _cityName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A cityname is required!"
            });
        }

        private bool ValidateCityName()
        {
            return _cityName.Validate();
        }
    }
}
