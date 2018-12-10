using System;
namespace Labb2OOAD.Models
{
    public class CityDtO
    {
        private string _street;
        private string _number;
        private string _zipcode;
        private string _city;
        private string _municipality;
        private string _code;
        private string _state;

        public CityDtO()
        {
        }

        public string Street
        {
            get { return _street; }
            set
            {
                if (value != _street)
                _street = value;
            }
        }

        public string Number
        {
            get { return _number; }
            set
            {
                if (value != _number)
                _number = value;
            }
        }

        public string ZipCode
        {
            get { return _zipcode; }
            set
            {
                if (value != _zipcode)
                _zipcode = value;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (value != _city)
                _city = value;
            }
        }

        public string Municipality
        {
            get { return _municipality; }
            set
            {
                if (value != _municipality)
                _municipality = value;
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if (value != _code)
                _code = value;
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (value != _state)
                _state = value;
            }
        }

    }
}

