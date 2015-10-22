using System;

namespace XamarinPushDemo
{
	public class RegistrationRequest
	{
		public String username { get; set; }
		public String password { get; set; }

		public RegistrationRequest (String username, String password)
		{
			this.username = username;
			this.password = password;
		}
	}
}

