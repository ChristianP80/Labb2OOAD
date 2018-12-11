using System;
using System.Windows.Input;
using Labb2OOAD.Models;
using Labb2OOAD.Validations;
using Labb2OOAD.Views;
using Xamarin.Forms;

namespace Labb2OOAD.ViewModels
{
    public class SearchViewModel : ExtendedBindableObject
    {
        const string _token = "8962900936131db7280a71d1f4162a99988fac18";

        public ICommand ValidateCityNameCommand => new Command(() => ValidateCityName());
        public ICommand ValidateStreetnameCommand => new Command(() => ValidateStreetname());
        //public ICommand SearchCityCommand => new Command (async () => await SearchCityAsync());
        public ICommand SearchCityCommand => new Command(
            execute: async () =>
            {
                await SearchCityAsync();
            },
            canExecute: () =>
            { 
                return Address.IsValid && Cityname.IsValid;
            });

        private void RefreshCanExecute()
        {
            (SearchCityCommand as Command).ChangeCanExecute();
        }

        private CityDtO _cityDtO;

        private ValidatableObject<string> _address;

        public ValidatableObject<string> Address
        {
            get { return _address; }
            set
            {
                _address = value;
                RaisePropertyChanged(() => Address);
                RefreshCanExecute();
            }
        }

        private ValidatableObject<string> _cityName;
        public ValidatableObject<string> Cityname
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                RaisePropertyChanged(() => Cityname);
                RefreshCanExecute();
            }
        }

        public SearchViewModel()
        {
            _address = new ValidatableObject<string>();
            _cityName = new ValidatableObject<string>();
            _cityDtO = new CityDtO();
            AddValidations();
        }

        private void AddValidations()
        {
            _cityName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A cityname is required!"
            });
            _address.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A streetname is required"
            });
        }

        private bool ValidateCityName()
        {
            return _cityName.Validate();
        }

        private bool ValidateStreetname()
        {
            return _address.Validate();
        }

        private async System.Threading.Tasks.Task SearchCityAsync()
        {
            var fetch = await ApiService.GetProductAsync("https://papapi.se/json/?s=" + Cityname.Value + "&token=" + _token);

            _cityDtO.City = fetch[0].City;
            _cityDtO.ZipCode = fetch[0].ZipCode;
            _cityDtO.Street = fetch[0].Street;

            var resultPage = new SearchResultPage();
            resultPage.BindingContext = _cityDtO;
            Cityname.Value = "";
            await Application.Current.MainPage.Navigation.PushAsync(resultPage);
            //await Application.Current.MainPage.Navigation.PushModalAsync(resultPage);
        }
    }
}


// implementera canexecute
// implementera ny metod refreshcanexecute