
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using CommonServiceLocator;
using Deals.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using JimBobBennett.MvvmLight.AppCompat;
using Android.Widget;
using System.ComponentModel;

namespace Deals.Droid
{
    [Activity(Label = "DetailDeal")]
    public class DetailDeal : AppCompatActivityBase
    {


        public DetailDealVM detailDealVM { get; private set; }
        private readonly List<Binding> _bindings = new List<Binding>();

        private TextView _mTitle;
        public TextView MTitle => _mTitle ?? (_mTitle = FindViewById<TextView>(Resource.Id.title));

        private TextView _mDescription;
        public TextView MDescription => _mDescription ?? (_mDescription = FindViewById<TextView>(Resource.Id.description));

        private ImageButton _mFavourite;
        public ImageButton MFavourite => _mFavourite ?? (_mFavourite = FindViewById<ImageButton>(Resource.Id.favorite));

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DealDetail);
            var param = Nav.GetAndRemoveParameter<Deal>(Intent);
            Resources res = Android.App.Application.Context.Resources;
            int id = (int)typeof(Resource.Drawable).GetField(param.ImageUrl).GetValue(null);
            ImageView imageView = (ImageView)FindViewById(Resource.Id.photo);
            imageView.TransitionName = Intent.GetStringExtra(param.ImageUrl);
            var myImage = BitmapFactory.DecodeResource(res, id);
            imageView.SetImageBitmap(myImage);

            detailDealVM = ViewModelLocator.detailViewModel;
            detailDealVM.Title = param.mCaption;
            detailDealVM.Description = param.mDesc;
            detailDealVM.Favourite = param.mFav;

            ToggleFavourite(detailDealVM.Favourite);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.SetBackgroundColor(Color.ParseColor("#d50000"));

            SetActionBar(toolbar);

            //ActionBar.SetTitle(param.mCaption);

            toolbar.SetNavigationIcon(Resource.Mipmap.ic_arrow_back);

            toolbar.SetCommand("NavigationOnClick", detailDealVM.GoBackCommand);

            MFavourite.SetCommand("Click", detailDealVM.AddFavourite);

            BindView();


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.detail_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



        public void BindView()
        {

            _bindings.Add(this.SetBinding(() => detailDealVM.Title, () => MTitle.Text, BindingMode.Default));
            _bindings.Add(this.SetBinding(() => detailDealVM.Description, () => MDescription.Text, BindingMode.Default));

            detailDealVM.PropertyChanged -= DetailViewModelOnPropertyChanged;
            detailDealVM.PropertyChanged += DetailViewModelOnPropertyChanged;

        }

        private void DetailViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {

            if (args.PropertyName == "Favourite")
            {
                ToggleFavourite(detailDealVM.Favourite);

            }
        }

        private void ToggleFavourite(bool value)
        {

            if (value)
            {
                MFavourite.SetImageResource(Resource.Mipmap.ic_favorite);

            }
            else
            {
                MFavourite.SetImageResource(Resource.Mipmap.ic_favorite_border);
            }
        }

        public AppCompatNavigationService Nav
        {
            get
            {
                return (AppCompatNavigationService)ServiceLocator.Current
                    .GetInstance<INavigationService>();
            }
        }



    }
}
