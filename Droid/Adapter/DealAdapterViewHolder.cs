using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;


namespace Deals.Droid.Adapter
{
    public class DealAdapterViewHolder: RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }
        public Button Percentage { get; private set; }

        // Get references to the views defined in the CardView layout.
        public DealAdapterViewHolder(View itemView, Action<int, ImageView> listener)
            : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            Percentage= itemView.FindViewById<Button>(Resource.Id.percentage);

            Typeface typeface = Typeface.CreateFromAsset(Android.App.Application.Context.Resources.Assets, "fonts/Pacifico-Regular.ttf");
            Caption.Typeface = typeface;
            Percentage.Typeface = typeface;


            // Detect user clicks on the item view and report which item
            // was clicked (by layout position) to the listener:
            itemView.Click += (sender, e) => listener(base.LayoutPosition, Image);
        }
    }


}

