﻿using System;
using System.Collections.Generic;
using bakedmobileapp.models;
using System.IO;
using Xamarin.Forms;

namespace bakedmobileapp
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
            //Opens the Sign In Page.
            signInButton.Clicked += SignInButton_Clicked;
            signUpButton.Clicked += SignUpButton_Clicked;
		}

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            var users = Directory.EnumerateFiles(baked_mobile_app.App.FolderPath, "*.bakedmobileapp.txt");

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
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveUser()
        {
            string filename = Path.Combine(baked_mobile_app.App.FolderPath, $"{Path.GetRandomFileName()}.bakedmobileapp.txt");

            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine(firstNameSignUp.Text);
                writer.WriteLine(lastNameSignUp.Text);
                writer.WriteLine(usernameSignUp.Text);
                writer.WriteLine(passwordSignUp.Text);
                writer.WriteLine(retypePasswordSignUp.Text);
            }
        }
    }
}
