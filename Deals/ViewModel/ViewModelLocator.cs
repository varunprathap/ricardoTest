using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Deals.ViewModel
{
    public class ViewModelLocator
    {
        public const string DetailPageKey = "DetailPage";

        static ViewModelLocator()
        {
            //set view model location provide.
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<DealViewModel>();
            SimpleIoc.Default.Register<DetailDealVM>();
        }


        public DealViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DealViewModel>();
            }
        }


        public DetailDealVM DetailViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DetailDealVM>();
            }
        }

        //return DealViewModel
        public static DealViewModel dealViewModel => ServiceLocator.Current.GetInstance<DealViewModel>();
        //return DetailViewModel
        public static DetailDealVM detailViewModel => ServiceLocator.Current.GetInstance<DetailDealVM>();
    }

}
