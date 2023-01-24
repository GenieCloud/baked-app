using System;
using System.Collections.Generic;
using bakedmobileapp.models;
using System.IO;
using Xamarin.Forms;
using baked_mobile_app;
using System.Linq;

namespace bakedmobileapp
{	
	public partial class SignInPage : ContentPage
	{
		public SignInPage ()
		{
			InitializeComponent ();
            //
            signUpButton.Clicked += SignUpButton_Clicked;
            signInButton.Clicked += SignInButton_Clicked;
		}

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            var users = Directory.EnumerateFiles(App.FolderPath, "*.bakedmobileapp.txt");

            bool registeredUserFound = false;

            var userData = new User();

            foreach (string user in users)
            {
                using (var reader = new StreamReader(user))
                {
                    //Make sure all data is accounted for.
                    userData.FirstName = reader.ReadLine();
                    userData.LastName = reader.ReadLine();
                    userData.UserName = reader.ReadLine();
                    userData.Email = reader.ReadLine();
                    userData.Password = reader.ReadLine();
                    userData.RetypePassword = reader.ReadLine();
                }

                //Check that both email and password match.
                if (String.Compare(userData.Email, emailSignIn.Text) == 0 && String.Compare(userData.Password, passwordSignIn.Text) == 0)
                {
                    registeredUserFound = true;
                    //By using break here we can exit the foreach loop and since the userData object was declared outside of the foreach loop, that means we have our user object already.
                    //So you pass that to the new main page when you push it below.
                    break;
                }
            }
            //If user found, display success alert and sign in.
            if (registeredUserFound)
            {
                await DisplayAlert("User Found.", "Signing In...", "OK");

                await Navigation.PushAsync(new SearchPage
                {
                    BindingContext = userData
                });
            }
            else
            {
                await DisplayAlert("User Not Found.", "Please try signing again.", "OK");
            }

        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage
            {

            });
        }
    }
}