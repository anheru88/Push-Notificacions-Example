using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Collections.Generic;
using System.Net.Http;

namespace XamarinPushDemo
{
	public class Dialog_Sing_Up : DialogFragment
	{
		Button btn;
		EditText username, password, confirmpassword; 
		private MobileServiceClient client;
		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.Dialog_SingUp, container, false);

			btn = view.FindViewById<Button> (Resource.Id.suBtn);
			username = view.FindViewById<EditText> (Resource.Id.suTxtUsername);
			password = view.FindViewById<EditText> (Resource.Id.suTxtPassword);
			confirmpassword =  view.FindViewById<EditText> (Resource.Id.suTxtPassword2);

			btn.Enabled = false;

			username.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				EnableSaveItemButton();
			};

			password.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				EnableSaveItemButton();
			};

			confirmpassword.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				EnableSaveItemButton();
			};
		
			btn.Click += async (sender, e) => {
				try {
					client = new MobileServiceClient (AppConstant.applicationURL, AppConstant.applicationKey);
					RegistrationRequest request = new RegistrationRequest(username.Text, password.Text);
					var user = await client.InvokeApiAsync<RegistrationRequest, Object>("CustomRegistration", request); 

					Toast.MakeText (Activity, "User Create Successfully!", ToastLength.Long).Show ();
					this.Dismiss();
				} catch (Exception ex) {
					Toast.MakeText (Activity, "Ups Something is wrong, try later!", ToastLength.Long).Show ();
					Console.WriteLine("Error" + ex.ToString());
				}
			};

			return view;
		}

		public override void OnActivityCreated (Android.OS.Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature (Android.Views.WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
		}

		private void EnableSaveItemButton(){
			if (username.Text.Length != 0 && password.Text.Length != 0 && confirmpassword.Text.Length != 0 && password.Text.Equals (confirmpassword.Text)) {
				btn.Enabled = true;				
			} else {
				btn.Enabled = false;				
			}
		}
	}
}

