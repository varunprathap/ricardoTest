
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
using Android.Widget;
using CommonServiceLocator;
using Deals.Model;
using GalaSoft.MvvmLight.Views;

namespace Deals.Droid
{
    [Activity(Label = "DetailDeal")]
    public class DetailDeal : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DealDetail);
            var param = Nav.GetAndRemoveParameter<DealItem>(Intent);
            Resources res = Android.App.Application.Context.Resources;
            int id = (int)typeof(Resource.Drawable).GetField(param.mDeal.ImageUrl).GetValue(null);
            ImageView imageView = (ImageView)FindViewById(Resource.Id.photo);
            imageView.TransitionName = Intent.GetStringExtra(param.mDeal.ImageUrl);
            var myImage = BitmapFactory.DecodeResource(res, id);
            imageView.SetImageBitmap(myImage);


        }

        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current
                    .GetInstance<INavigationService>();
            }
        }
    }
}
