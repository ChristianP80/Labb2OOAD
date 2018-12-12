using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Labb2OOAD.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        async void AnimatePoo(object sender, System.EventArgs e)
        {
            //await pooButton.TranslateTo(100, 0, 500, Easing.BounceOut);
            //await pooButton.TranslateTo(0, 0, 500, Easing.BounceIn);
            await pooButton.ScaleTo(8, 1000);
            await pooButton.ScaleTo(5, 1000, Easing.SpringIn);
            await pooButton.RotateTo(720);
            await pooButton.RotateTo(0, 1000);
            await pooButton.FadeTo(0, 1000, Easing.SinOut);
            await pooButton.FadeTo(100, 1000, Easing.SinIn);
        }
    }
}
