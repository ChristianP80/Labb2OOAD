using System;
using Labb2OOAD.Views;
using Xamarin.Forms;

namespace Labb2OOAD.ViewModels
{
    public class TestVM
    {
        public TestVM()
        {
        }

        public Command NavCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new SearchResultPage());
                });

            }
        }
        public Command NavBackCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
