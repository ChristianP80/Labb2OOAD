using System;
using Xamarin.Forms;
using Labb2OOAD.iOS;
using Labb2OOAD.Native;
using AVFoundation;
using AudioUnit;

[assembly: Dependency(typeof(TextToSpeech))]
namespace Labb2OOAD.iOS
{
    public class TextToSpeech : ITextToSpeech
    {
        public TextToSpeech()
        {
        }

        public void Speak(string speakText)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(speakText)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 2,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}
