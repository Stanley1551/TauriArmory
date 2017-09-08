using Xamarin.Forms;
using TauriArmory.Droid;
using TauriArmory;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using Android.OS;

[assembly: ExportRenderer(typeof(CharacterNameEntry), typeof(CharacterNameEntryRenderer))]
namespace TauriArmory.Droid
{
    public class CharacterNameEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetPadding(180, 60, 0, 0);
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Black);
                
            }
        }
    }
}