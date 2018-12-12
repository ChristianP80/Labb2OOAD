using System;
using System.Collections.Generic;
using Labb2OOAD.Views;
using Labb2OOAD.Native;
using Xamarin.Forms;

namespace Labb2OOAD.Views
{
    public partial class SpeechPage : ContentPage
    {
        public SpeechPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var OSinformation = DependencyService.Get<IPlatform>();
            string OSText = OSinformation.GetOS();
            string OSVersion = OSinformation.GetVersion();

            DependencyService.Get<ITextToSpeech>().Speak("You are using " + OSText + " on version" + OSVersion);
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            var EventText = SpeechText.Text;
            SpeechText.Text = "";

            DependencyService.Get<ITextToSpeech>().Speak(EventText);
        }
    }
}
