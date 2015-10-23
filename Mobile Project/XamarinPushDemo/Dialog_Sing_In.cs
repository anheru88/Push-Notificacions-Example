using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Collections.Generic;
using System.Net.Http;
using Android.Content;
using Android.OS;

namespace XamarinPushDemo
{
	public class Dialog_Sing_In: DialogFragment
	{
		Button btn;
		EditText username, password;
		private MobileServiceClient client;
		private MobileServiceUser user;
		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.Dialog_SingIn, container, false);

			btn = view.FindViewById<Button> (Resource.Id.siBtn);
			username = view.FindViewById<EditText> (Resource.Id.siTxtUsername);
			password = view.FindViewById<EditText> (Resource.Id.siTxtPassword);

			btn.Enabled = false;

			username.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				EnableSaveItemButton();
			};

			password.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				EnableSaveItemButton();
			};

			btn.Click += async (sender, e) => {
				try {
					client = new MobileServiceClient (AppConstant.applicationURL, AppConstant.applicationKey);
					LoginRequest request = new LoginRequest(username.Text, password.Text);
					this.user = await client.InvokeApiAsync<LoginRequest, MobileServiceUser>("CustomLogin", request);
					Toast.MakeText (Activity, "User Login Successfully!", ToastLength.Long).Show ();

					Intent intent = new Intent(Activity, typeof(ToDoActivity));

					intent.PutExtra("UserID", user.UserId);
					intent.PutExtra("UserToken", user.MobileServiceAuthenticationToken);

					this.StartActivity(intent);

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
			if (username.Text.Length != 0 && password.Text.Length != 0) {
				btn.Enabled = true;				
			} else {
				btn.Enabled = false;				
			}
		}

		public MobileServiceUser getUser(){
			if (user != null) {
				return user;
			}
			return null;
		}
	}
}