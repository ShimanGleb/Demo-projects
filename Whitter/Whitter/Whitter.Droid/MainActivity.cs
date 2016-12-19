using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Whitter.Droid
{
    [Activity(Label = "Whitter", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            
            SetPage(App.GetMainPage());
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Finish();
        }
    }
}

