using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinMastering
{
    // Summary RoutingEffect:
    //     Platform-independent effect that wraps an inner effect, which is usually platform-specific.
    public class FocusEffect : RoutingEffect
    {
        //The FocusEffect class calls the base class constructor, passing in a parameter 
        //consisting of a concatenation of the resolution group name (specified using the ResolutionGroupName attribute on the effect class),
        //and the unique ID that was specified using the ExportEffect attribute on the effect class.
        public FocusEffect() : base(effectId: "Xamarin.FocusEffect")
        {
        }
    }
}
