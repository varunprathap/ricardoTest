// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Deals.iOS.TableCell
{
    [Register ("DealTableCell")]
    partial class DealTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Caption { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Image { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Caption != null) {
                Caption.Dispose ();
                Caption = null;
            }

            if (Image != null) {
                Image.Dispose ();
                Image = null;
            }
        }
    }
}