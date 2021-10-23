using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace LearningXamarin.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            //Adding Maps 
            Xamarin.FormsMaps.Init(); //Adds function to display maps
            //Right Click on info.plist -> Open With - > Generic Plist Editor and add permission to either always or in use location under privacy.

            //Adding Database Location
            string dbName = "app_db.sqlite";
            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(folderPath, dbName); //Full path will have path to folder and dbname file
            LoadApplication(new App(fullPath)); //To locath folderpath and db file and pass through as constructor

            return base.FinishedLaunching(app, options);
        }
    }
}
