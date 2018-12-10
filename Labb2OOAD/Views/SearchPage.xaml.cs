using System;
using System.Collections.Generic;
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
        }
    }
}
