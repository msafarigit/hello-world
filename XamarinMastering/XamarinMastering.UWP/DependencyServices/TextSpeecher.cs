using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.UWP.DependencyServices.TextSpeecher))]
namespace XamarinMastering.UWP.DependencyServices
{
    public class TextSpeecher : ITextSpeecher
    {
        public TextSpeecher()
        {
        }

        public async void Speak(string text)
        {
            MediaElement mediaElement = new MediaElement();
            SpeechSynthesizer synth = new SpeechSynthesizer();
            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}
