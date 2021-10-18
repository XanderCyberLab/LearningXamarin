using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningXamarin.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelPage : ContentPage
    {
        public TravelPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post() //Define a new post
            {
                Experience = experienceEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) 
                //using statements when making sqlite connections to databases.
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows > 0)
                    DisplayAlert("Success,", "Entry Received", "Message");
                else
                    DisplayAlert("Failed,", "Entry Not Received", "Try Again");
            }
        }
    }
}