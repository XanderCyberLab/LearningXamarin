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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation); //Constructor needs path of database location
            conn.CreateTable<Post>();//Will ignore if a Table is already created. 
            var posts = conn.Table<Post>().ToList(); //Creates a list of Post objects. Need to return type of table(POST) create var posts 
            conn.Close();//Need to close database after reading


            
        }
    }
}