using System;
using System.Collections.Generic;
using bakedmobileapp.models;
using System.IO;
using Xamarin.Forms;
using baked_mobile_app;
using System.Linq;

namespace bakedmobileapp
{
	public partial class SignUpPage : ContentPage
	{
        public SignUpPage ()
		{
			InitializeComponent ();
            //Opens the Sign In Page.
            signInButton.Clicked += SignInButton_Clicked;
            //Saves the user for sigining into the mobile app.
            signUpButton.Clicked += SignUpButton_Clicked;
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            var users = Directory.EnumerateFiles(App.FolderPath, "*.bakedmobileapp.txt");

            var userData = new User();

            //Check for duplicate emails and usernames.
            bool duplicateEmailUsername = false;

            //Check if fields are empty
            if (String.IsNullOrEmpty(firstNameSignUp.Text) || String.IsNullOrEmpty(lastNameSignUp.Text) || String.IsNullOrEmpty(usernameSignUp.Text) || String.IsNullOrEmpty(passwordSignUp.Text) || String.IsNullOrEmpty(retypePasswordSignUp.Text))
            {
                await DisplayAlert("One or more fields are empty.", "Please fill out each field.", "OK");
            //Check if the email entered is a valid email address.
            } else if (!emailSignUp.Text.Contains("@"))
            {
                await DisplayAlert("Invalid Email.", "Please enter a valid e-mail address.", "OK");
            //Check if the passwords match.
            } else if (passwordSignUp.Text != retypePasswordSignUp.Text)
            {
                await DisplayAlert("Passwords do not match.", "Please make sure the password and retype password match.", "OK");
            }
            //Make sure all data is accounted for using a StreamReader
            foreach (var user in users)
            {
                using (var reader = new StreamReader(user))
                {
                    userData.FirstName = reader.ReadLine();
                    userData.LastName = reader.ReadLine();
                    userData.UserName = reader.ReadLine();
                    userData.Email = reader.ReadLine();
                    userData.Password = reader.ReadLine();
                    userData.RetypePassword = reader.ReadLine();
                }
                //Compare the userData.Email and emailSignUp.Text to confirm the email is not taken.
                //Compare the userData.Username and usernameSignUp.Text to confirm the username is not taken.
                if (String.Compare(userData.Email, emailSignUp.Text) == 0 && String.Compare(userData.UserName, usernameSignUp.Text) == 0)
                {
                    duplicateEmailUsername = true;

                    break;
                }
            }
            //Check if the Email/Username is available and provide 
            if (duplicateEmailUsername)
            {
                await DisplayAlert("Success!", "Your registration is complete!", "OK");
                SaveUser();
                await Navigation.PushAsync(new SignInPage
                {
                    BindingContext = userData
                });
            }
            else
            {
                await DisplayAlert("Username/Email already in use.", "Please use another email or username.", "OK");
            }
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveUser()
        {
            string filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.bakedmobileapp.txt");

            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine(firstNameSignUp.Text);
                writer.WriteLine(lastNameSignUp.Text);
                writer.WriteLine(usernameSignUp.Text);
                writer.WriteLine(emailSignUp.Text);
                writer.WriteLine(passwordSignUp.Text);
                writer.WriteLine(retypePasswordSignUp.Text);
            }
        }
    }
}

