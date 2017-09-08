using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: ExportRenderer(typeof(CharacterNameEntry), typeof(CharacterNameEntryRenderer))]
namespace TauriArmory.Droid.CustomRenderers
    {
    
        public class CharacterNameEntryRenderer : EntryRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);

                if (Control != null)
                {
                    Control.SetBackgroundResource(Resource.Drawable.button);
                }
            }
        }
    }
