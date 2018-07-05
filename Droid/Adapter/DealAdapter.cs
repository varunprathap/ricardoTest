using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Graphics;
using Android.Content.Res;
using Android.Widget;
using Deals.ViewModel;
using Deals.Model;

namespace Deals.Droid.Adapter
{
    public class DealAdapter: RecyclerView.Adapter
    {
       

        // Load the adapter with the data set
        public DealAdapter()
        {
           
        }



        // Fill in the contents of the photo card (invoked by the layout manager):
        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DealAdapterViewHolder vh = holder as DealAdapterViewHolder;
            Resources res = Android.App.Application.Context.Resources;
            // Set the ImageView and TextView in this ViewHolder's CardView 
            // from this position in the photo album:
            int id = (int)typeof(Resource.Drawable).GetField(ViewModelLocator.dealViewModel.Deals[position].ImageUrl).GetValue(null);
            // Converting Drawable Resource to Bitmap
            var myImage = BitmapFactory.DecodeResource(res, id);
            vh.Image.SetImageBitmap(myImage);
            vh.Caption.Text = ViewModelLocator.dealViewModel.Deals[position].Caption;
            vh.Percentage.Text = ViewModelLocator.dealViewModel.Deals[position].Percentage.ToString()+"%";
            vh.Image.TransitionName = ViewModelLocator.dealViewModel.Deals[position].ImageUrl;
        }

        // Return the number of photos available in the photo album:
        public override int ItemCount
        {
            get { return ViewModelLocator.dealViewModel.Deals.Count; }
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position, ImageView view)
        {
            var item = new DealItem();
            item.mDeal = ViewModelLocator.dealViewModel.Deals[position];
            item.mImage = view;
            ViewModelLocator.dealViewModel.NavigateCommand.Execute(item);
           
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.DealView, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            DealAdapterViewHolder vh = new DealAdapterViewHolder(itemView, OnClick);
            return vh;
        }
    }
}
