using System;
namespace Labb2OOAD.Models
{
    public class CityDtO
    {
        public string _city;
        public string _webAdress;
        public string _email;
        public string _population;
        public string _municipalCode;

        public CityDtO()
        {
        }

        public CityDtO(string City, string WebAdress, string Email, string Population, string MunicipalCode)
        {
            _city = City;
            _webAdress = WebAdress;
            _email = Email;
            _population = Population;
            _municipalCode = MunicipalCode;
        }
    }
}
