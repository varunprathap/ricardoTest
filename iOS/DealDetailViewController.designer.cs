// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Deals.iOS
{
    [Register ("DealDetailViewController")]
    partial class DealDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView DealImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FavButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DealImage != null) {
                DealImage.Dispose ();
                DealImage = null;
            }

            if (FavButton != null) {
                FavButton.Dispose ();
                FavButton = null;
            }
        }
    }
}