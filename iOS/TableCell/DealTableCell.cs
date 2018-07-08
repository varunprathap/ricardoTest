using System;

using Deals.ViewModel;
using Foundation;

using UIKit;

namespace Deals.iOS.TableCell
{
    public partial class DealTableCell : UITableViewCell
    {


      
        protected DealTableCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        internal void Configure(Deal deal){

            base.LayoutSubviews();
            Caption.Text = deal.Caption;
            Image.Image = UIImage.FromBundle(deal.ImageUrl);
        }
    }
}
