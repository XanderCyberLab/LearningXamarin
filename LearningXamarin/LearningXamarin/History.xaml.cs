using LearningXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()//a way to refresh everytime go to history page. 
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))//Constructor needs path of database location
            {
                conn.CreateTable<Post>();//Will ignore if a Table is already created. 
                var posts = conn.Table<Post>().ToList(); //Creates a list of Post objects. Need to return type of table(POST) create var posts 
                postsListView.ItemsSource = posts; //listview created 
            }
            //conn.Close();//Need to close database after reading <-- Not needed when using is added to the connection. Acts like a close


            
        }

        private void postsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postsListView.SelectedItem as Post;

            if(selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}