using System;
using UIKit;

namespace Deals.iOS.TableCell
{
    public class CustomCell:UITableViewCell
    {
        public UILabel caption;
        public CustomCell(IntPtr handler):base(handler)
        {
            InitCell();
        }

        public CustomCell(){
            InitCell();
        }


        private void InitCell(){

            caption = new UILabel();
            AddSubview(caption);


        }

        internal void Configure(Deal deal)
        {

            base.LayoutSubviews();
            caption.Text = deal.Caption;
        }
    }
}
