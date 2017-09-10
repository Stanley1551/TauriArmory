using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using System;

namespace TauriArmory.Droid
{
    [Activity(Label = "TauriArmory.Android",Icon ="@drawable/ic_launcher", Theme = "@style/MyTheme.Base", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public event System.EventHandler Disconnected;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            
            LoadApplication(new App());
            UserDialogs.Init(this);

            if (!isConnected()) UserDialogs.Instance.Alert("Internet connection is not available!");

        }
            private bool isConnected()
        {
            ConnectivityManager Cmanager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo networkInfo = Cmanager.ActiveNetworkInfo;
            
            if (networkInfo is null) return false;
            if (networkInfo.IsConnected==null) return false;
            if (!networkInfo.IsConnected) return false;
            return true;
        }

    }
    
}