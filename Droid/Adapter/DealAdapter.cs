using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Graphics;
using Android.Content.Res;
using Android.Widget;
using Deals.ViewModel;
using System.ComponentModel;

namespace Deals.Droid.Adapter
{
    public class DealAdapter : RecyclerView.Adapter
    {
        public Filter Filter { get; private set; }

        // Load the adapter with the data set
        public DealAdapter()
        {
            ViewModelLocator.dealViewModel.PropertyChanged -= DealViewModelOnPropertyChanged;
            ViewModelLocator.dealViewModel.PropertyChanged += DealViewModelOnPropertyChanged;
        }

        private void DealViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            //notify the adapater when searchtext changes.
            this.NotifyDataSetChanged();
        }

        // Fill in the contents
        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = ViewModelLocator.dealViewModel.Deals[position];
            ((DealAdapterViewHolder)holder).BindDealViewModel(item);

        }


        public override int ItemCount
        {
            get { return ViewModelLocator.dealViewModel.Deals.Count; }
        }



        // Raise an event when the item-click takes place:
        void OnClick(int position, ImageView view)
        {

            ViewModelLocator.dealViewModel.NavigateCommand.Execute(ViewModelLocator.dealViewModel.Deals[position]);

        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the deal:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.DealView, parent, false);
            DealAdapterViewHolder vh = new DealAdapterViewHolder(itemView, OnClick);
            return vh;
        }
    }
}
