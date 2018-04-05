using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinMastering
{
    // Summary RoutingEffect:
    //     Platform-independent effect that wraps an inner effect, which is usually platform-specific.
    public class HyperlinkEffect : RoutingEffect
    {
        public HyperlinkEffect() : base(effectId: "Xamarin.HyperlinkEffect")
        {

        }
    }
}
