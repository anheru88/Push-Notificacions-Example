using System;
using Android.App;

namespace XamarinPushDemo
{
	public class Dialog_Sing_Up : DialogFragment
	{
		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.Dialog_SingUp, container, false);

			return view;
		}

		public override void OnActivityCreated (Android.OS.Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature (Android.Views.WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);

		}
	}
}

