using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using Foundation;
using XamarinMastering.iOS.Effects;

[assembly: ExportEffect(typeof(HyperlinkEffect), "HyperlinkEffect")]
namespace XamarinMastering.iOS.Effects
{
    public class HyperlinkEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control as UILabel;
                control.TextColor = Helpers.ColorHelper.PlatformAccentColor;

                UITapGestureRecognizer labelTap = new UITapGestureRecognizer(() => 
                {
                     
                });
                
                control.UserInteractionEnabled = true;
                control.AddGestureRecognizer(labelTap);

                SetUnderline(true);
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDetached()
        {
            SetUnderline(false);
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == Label.TextProperty.PropertyName || args.PropertyName == Label.FormattedTextProperty.PropertyName)
            {
                SetUnderline(true);
            }
        }
        
        private void SetUnderline(bool underlined)
        {
            try
            {
                UILabel label = (UILabel)Control;
                NSMutableAttributedString text = (NSMutableAttributedString)label.AttributedText;
                NSRange range = new NSRange(0, text.Length);

                if (underlined)
                {
                    text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
                }
                else
                {
                    text.RemoveAttribute(UIStringAttributeKey.UnderlineStyle, range);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
} 