using System;
using Xamarin.Forms;
using Labb2OOAD.Droid;
using Labb2OOAD.Native;
using Android.Speech.Tts;
using Android.Runtime;

[assembly: Dependency(typeof(TextToSpeechClass))]
namespace Labb2OOAD.Droid
{
    public class TextToSpeechClass : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public void Speak(string speakText)
        {
            toSpeak = speakText;
            if (speaker == null)
            {
                speaker = new TextToSpeech(Forms.Context, this);
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }


    }
}
