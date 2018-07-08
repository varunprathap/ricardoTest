using Airbnb.Lottie;
using CommonServiceLocator;
using Foundation;
using GalaSoft.MvvmLight.Views;
using System;
using System.Drawing;
using UIKit;

namespace Deals.iOS
{
    public partial class DealDetailViewController : UIViewController
    {
        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public DealDetailViewController(IntPtr handle) : base(handle)
        {

        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var param = (Deal)Nav.GetAndRemoveParameter(this);

            DealImage.Image = UIImage.FromBundle(param.ImageUrl);

            FavButton.SetImage(UIImage.FromBundle("fav"), UIControlState.Normal);

            LOTAnimationView animation = LOTAnimationView.AnimationNamed("anim");
            animation.TranslatesAutoresizingMaskIntoConstraints = false;
            var animLayout = new[]{
                animation.LeadingAnchor.ConstraintEqualTo(this.DealImage.SafeAreaLayoutGuide.LeadingAnchor),
                animation.TopAnchor.ConstraintEqualTo(this.DealImage.SafeAreaLayoutGuide.TopAnchor),
                animation.BottomAnchor.ConstraintEqualTo(this.DealImage.SafeAreaLayoutGuide.BottomAnchor),
                animation.TrailingAnchor.ConstraintEqualTo(this.DealImage.SafeAreaLayoutGuide.TrailingAnchor)
            };
            animation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this.View.AddSubview(animation);
            animation.PlayWithCompletion((animationFinished) =>
            {

            });

            NSLayoutConstraint.ActivateConstraints(animLayout);




        }


    }
}