using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace Deals.ViewModel
{
    public class ViewModelLocator
    {
        public const string DetailPageKey = "DetailPage";

        static ViewModelLocator()
        {

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
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

        public static DealViewModel dealViewModel => ServiceLocator.Current.GetInstance<DealViewModel>();
        public static DetailDealVM detailViewModel => ServiceLocator.Current.GetInstance<DetailDealVM>();
    }

}
