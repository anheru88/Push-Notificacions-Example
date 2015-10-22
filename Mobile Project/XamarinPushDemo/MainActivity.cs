
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

namespace XamarinPushDemo
{	
	[Activity (MainLauncher = true, 
		Icon="@drawable/ic_launcher", Label="MainActivity",
		Theme="@style/AppTheme")]
	public class MainActivity : Activity
	{
		private Button BtnSignUp, BtnSignIn;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Login);

			BtnSignUp = FindViewById<Button> (Resource.Id.btnSingUp);
			BtnSignIn = FindViewById<Button> (Resource.Id.btnSingIn);

			BtnSignUp.Click += (object sender, EventArgs e) => 
			{
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				Dialog_Sing_Up signUpDialog = new Dialog_Sing_Up();
				signUpDialog.Show(transaction, "Dialog Fragment");

			};

			BtnSignIn.Click += (object sender, EventArgs e) => 
			{
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				Dialog_Sing_In signInDialog = new Dialog_Sing_In();
				signInDialog.Show(transaction, "Dialog Fragment");

			};

		}


	}
}

