using System;
using Android.Widget;

namespace Deals.Droid.Interface
{
    public interface IDealItemClickListener
    {
        void OnDealItemClick(int pos, Deal deal, ImageView imageView);
    }
}
