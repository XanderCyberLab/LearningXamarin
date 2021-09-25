using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text); // Checks if Email box is empty
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text); // Checks if Password box is empty

            if(isEmailEmpty || isPasswordEmpty) // No need == True since it's already a Boolean
            { // No Valid Login Info Enter to Move Forward

            }
            else
            { // Login Info Enter to Move Forward
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
