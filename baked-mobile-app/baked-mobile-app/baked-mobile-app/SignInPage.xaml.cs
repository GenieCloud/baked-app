using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace bakedmobileapp
{	
	public partial class SignInPage : ContentPage
	{	
		public SignInPage ()
		{
			InitializeComponent ();

            signUpButton.Clicked += SignUpButton_Clicked;
		}

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage
            {

            });
        }
    }
}

