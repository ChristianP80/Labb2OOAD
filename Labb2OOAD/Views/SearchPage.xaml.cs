using System;
using System.Collections.Generic;
using Labb2OOAD.Models;
using Labb2OOAD.ViewModels;
using Xamarin.Forms;

namespace Labb2OOAD.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            SearchViewModel test = new SearchViewModel();
            BindingContext = test;

            MessagingCenter.Subscribe<object>(this, "Arrived", (sender) => {
                // do something whenever the "Arrived" message is sent from whatever type 
                //<object> is.

                DisplayAlert("Error", "Enter a valid street name and city", "Continue");
            });
        }

    }
}
