using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;

namespace ANdroidLocal
{
	[Activity (Label = "ANdroidLocal", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				Configuration cfg = new Configuration();
				bool langIsAr=this.Intent.GetBooleanExtra("lang",true);
				if(langIsAr)
				{
					cfg.Locale = new Java.Util.Locale("ar");
					langIsAr=!langIsAr;
				}

				else if(!langIsAr)
				{
					cfg.Locale = new Java.Util.Locale("en");
					langIsAr=!langIsAr;
				}

				this.Resources.UpdateConfiguration(cfg, null);

				Intent intent = new Intent(this, typeof(MainActivity));

				intent.SetFlags(ActivityFlags.NewTask
					| ActivityFlags.ClearTop);
				intent.PutExtra("lang",langIsAr);
				this.StartActivity(intent);
			};
		}
	}
}


