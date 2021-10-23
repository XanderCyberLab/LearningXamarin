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
    public partial class PostDetailPage : ContentPage
    {

        Post selectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;//so other methods have access

            experienceLabel.Text = selectedPost.Experience;
        }

        private void updatedButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceLabel.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //using statements when making sqlite connections to databases.
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success,", "Entry Updated", "Message");
                else
                    DisplayAlert("Failed,", "Entry Not Updated", "Try Again");
            }
        }
        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //using statements when making sqlite connections to databases.
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success,", "Entry Deleted", "Message");
                else
                    DisplayAlert("Failed,", "Entry Not Deleted", "Try Again");
            }
        }
    }
}