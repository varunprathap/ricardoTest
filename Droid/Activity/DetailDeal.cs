
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
using Com.Airbnb.Lottie;
using Android.Animation;
using System.Threading.Tasks;

namespace Deals.Droid
{
    [Activity(Label = "DetailDeal")]
    public class DetailDeal : AppCompatActivityBase
    {

        //Detail view model for the view.
        public DetailDealVM detailDealVM { get; private set; }

        //bindings on the view.
        private readonly List<Binding> _bindings = new List<Binding>();

        //Price Of Deal
        private TextView _mPrice;
        public TextView MPrice => _mPrice ?? (_mPrice = FindViewById<TextView>(Resource.Id.price));

        //Title Of Deal
        private TextView _mTitle;
        public TextView MTitle => _mTitle ?? (_mTitle = FindViewById<TextView>(Resource.Id.title));

        //Description Of Deal
        private TextView _mDescription;
        public TextView MDescription => _mDescription ?? (_mDescription = FindViewById<TextView>(Resource.Id.description));

        //Favourite Of Deal
        private ImageButton _mFavourite;
        public ImageButton MFavourite => _mFavourite ?? (_mFavourite = FindViewById<ImageButton>(Resource.Id.favorite));

        //Animation On Fav Click.
        private LottieAnimationView _mAnim;
        public LottieAnimationView Manim => _mAnim ?? (_mAnim = FindViewById<LottieAnimationView>(Resource.Id.animation_view)
                                                      );

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DealDetail);
            //get the deal from navigation params.
            var param = Nav.GetAndRemoveParameter<Deal>(Intent);

            //set the image 
            Resources res = Android.App.Application.Context.Resources;
            int id = (int)typeof(Resource.Drawable).GetField(param.ImageUrl).GetValue(null);
            ImageView imageView = (ImageView)FindViewById(Resource.Id.photo);
            imageView.TransitionName = Intent.GetStringExtra(param.ImageUrl);
            var myImage = BitmapFactory.DecodeResource(res, id);
            imageView.SetImageBitmap(myImage);

            //intialize view model and set value.
            detailDealVM = ViewModelLocator.detailViewModel;
            detailDealVM.Title = param.mCaption;
            detailDealVM.Description = param.mDesc;
            detailDealVM.Favourite = param.mFav;
            detailDealVM.Price = param.mPrice;

            //Toggle the favourite button icon image.
            ToggleFavourite(detailDealVM.Favourite);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.SetBackgroundColor(Color.ParseColor("#d50000"));
            SetActionBar(toolbar);
            toolbar.SetNavigationIcon(Resource.Mipmap.ic_arrow_back);

            //set the command property on navigation button.
            toolbar.SetCommand("NavigationOnClick", detailDealVM.GoBackCommand);

            //Set the command property on button.
            MFavourite.SetCommand("Click", detailDealVM.AddFavourite);

            //Bind the view with viewmodel data and notification.
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
            _bindings.Add(this.SetBinding(() => detailDealVM.Price, () => MPrice.Text, BindingMode.Default));
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

        //Toggle favourite button action.
        private void ToggleFavourite(bool value)
        {

            if (value)
            {
                MFavourite.SetImageResource(Resource.Mipmap.ic_favorite);
                Manim.Visibility = ViewStates.Visible;
                Manim.PlayAnimation();
                //delay to dismiss the animation.
                Task.Run(async () => { await Task.Delay(1500);
                    //new Handler().Post(UpdatePlayButtonText);
                    Manim.Visibility = ViewStates.Invisible;
                    Manim.Progress = 1.0f;
                });


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
