using System;
using System.Collections.Generic;
using System.Text;
using AVFoundation;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.iOS.TextSpeecher))]
namespace XamarinMastering.iOS
{
    public class TextSpeecher : ITextSpeecher
    {
        public TextSpeecher() { }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();//AudioVideoSpeechSynthesizer
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}