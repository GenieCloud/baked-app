using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace bakedmobileapp
{	
	public partial class SignUpPage : ContentPage
	{	
		public SignUpPage ()
		{
			InitializeComponent ();
            signInButton.Clicked += SignInButton_Clicked;
		}

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage
            {

            });
        }
    }
}

