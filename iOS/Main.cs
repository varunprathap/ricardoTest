using System;
using System.Collections.Generic;
using System.Linq;
using Deals.ViewModel;
using Foundation;
using UIKit;

namespace Deals.iOS
{
    public class Application
    {
        private static readonly Lazy<ViewModelLocator> Locator = new Lazy<ViewModelLocator>(() => new ViewModelLocator());
        public static ViewModelLocator viewModelLocator => Locator.Value;

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
