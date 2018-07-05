using System.Collections.ObjectModel;
using Deals.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Deals.ViewModel
{
    public class DealViewModel : ViewModelBase
    {
        private RelayCommand<DealItem> navigateCommand;
        private readonly INavigationService navigationService;
        private readonly ObservableCollection<Deal> _deals = new ObservableCollection<Deal>(){

                new Deal { mPhotoID = 1001, mCaption = "Lomo'Instant", mDesc = "Lomo'Instant Marrakesh Edition Lens Combo Instant Film Camera Flash", mPercentage = 50, mImageUrl = "aaa" },
                new Deal { mPhotoID = 1002, mCaption = "Adidas Gazelle OG", mDesc = "ADIDAS GAZELLE OG (Q23178) GREEN ADIDAS ORIGINALS CASUAL SHOES SNEAKERS", mPercentage = 40, mImageUrl = "eee" },
                new Deal { mPhotoID = 1003, mCaption = "Adidas Dragon (S81908)", mDesc = "NEW ADIDAS DRAGON (S81908) All Sz ORIGINALS CASUAL SHOES SNEAKERS", mPercentage = 10, mImageUrl = "ggg" },
                new Deal { mPhotoID = 1004, mCaption = "adidas Jogger", mDesc = "gym shoe new dragon sl 72", mPercentage = 40, mImageUrl = "fff" },
                new Deal { mPhotoID = 1005, mCaption = "Columbia River Knife", mDesc = "Columbia River Knife and Tool's Eat N Tool 9100C Silver Multi Too", mPercentage = 30, mImageUrl = "ddd" },
                new Deal { mPhotoID = 1007, mCaption = "Watershed Chattooga Dry", mDesc = "Watershed Chattooga Dry Duffel 3 Colors Outdoor Duffel", mPercentage = 10, mImageUrl = "bbb" }

            };
        public ObservableCollection<Deal> Deals { get; set; }

        public DealViewModel(INavigationService _navigationService)
        {
            Deals = _deals;
            navigationService = _navigationService;
        }


        public RelayCommand<DealItem> NavigateCommand
        {
            get
            {
                return navigateCommand
                    ?? (navigateCommand = new RelayCommand<DealItem>((data) => navigationService.NavigateTo(
                            ViewModelLocator.DetailPageKey, data)));
            }
        }
    }
}
