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

        public ICommand ValidateCityNameCommand { get; set; }
        public ICommand ValidateStreetnameCommand { get; set; }
        public ICommand SearchCityCommand { get; set; }



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
            
        SearchCityCommand = new Command(
            execute: async () =>
            {
                await SearchCityAsync();
            },
            canExecute: () =>
            {
                return Address.IsValid && Cityname.IsValid;
            });

            ValidateStreetnameCommand = new Command(ValidateStreetname);
            ValidateCityNameCommand = new Command(ValidateCityName);
        }

        private void AddValidations()
        {
            _cityName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A cityname is required!"
            });
            _address.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A valid streetname is required"
            });
        }

        private void ValidateCityName()
        {
            _cityName.Validate();
            RefreshCanExecute();
        }

        private void ValidateStreetname()
        {
            _address.Validate();
            RefreshCanExecute();
        }

        private async System.Threading.Tasks.Task SearchCityAsync()
        {

            // https://papapi.se/json/?s=Birger+Jarlsgatan&c=Stockholm&token=DIN_TOKEN
            var fetch = await ApiService.GetProductAsync("https://papapi.se/json/?s=" + Address.Value + "&c=" + Cityname.Value + "&token=" + _token);

            if (fetch.Length < 1)
            {
                MessagingCenter.Send<object>(this, "Arrived");

                Cityname.Value = "";
                Address.Value = "";
                return;
            }

            _cityDtO.City = fetch[0].City;
            _cityDtO.ZipCode = fetch[0].ZipCode;
            _cityDtO.Street = fetch[0].Street;

            var resultPage = new SearchResultPage();
            resultPage.BindingContext = _cityDtO;
            Cityname.Value = "";
            Address.Value = "";
            await Application.Current.MainPage.Navigation.PushAsync(resultPage);
            //await Application.Current.MainPage.Navigation.PushModalAsync(resultPage);
        }
    }
}


// implementera canexecute
// implementera ny metod refreshcanexecute