using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Deals.ViewModel
{
    public class DealViewModel : ViewModelBase
    {
        //Navigation command.
        private RelayCommand<Deal> navigateCommand;
        //search command for searchview textchange.
        private RelayCommand<string> searchCommand;
        private readonly INavigationService navigationService;
        //sample deals.
        private ObservableCollection<Deal> _refDeals = new ObservableCollection<Deal>(){

            new Deal { mPhotoID = 1001, mCaption = "Lomo'Instant", mDesc = "Lomo'Instant Marrakesh Edition Lens Combo Instant Film Camera Flash", mPercentage = 50, mImageUrl = "aaa",mTags="camera",mFav=true,mPrice="€250" },
            new Deal { mPhotoID = 1002, mCaption = "Adidas Gazelle OG", mDesc = "ADIDAS GAZELLE OG (Q23178) GREEN ADIDAS ORIGINALS CASUAL SHOES SNEAKERS", mPercentage = 40, mImageUrl = "eee",mTags="shoe",mFav=false ,mPrice="€120"},
            new Deal { mPhotoID = 1003, mCaption = "Adidas Dragon ", mDesc = "NEW ADIDAS DRAGON (S81908) All Sz ORIGINALS CASUAL SHOES SNEAKERS", mPercentage = 10, mImageUrl = "ggg",mTags="shoe",mFav=false,mPrice="€100" },
            new Deal { mPhotoID = 1004, mCaption = "adidas Jogger", mDesc = "gym shoe new dragon sl 72", mPercentage = 40, mImageUrl = "fff",mTags="shoe",mFav=true ,mPrice="€50"},
            new Deal { mPhotoID = 1005, mCaption = "Columbia Knife", mDesc = "Columbia River Knife and Tool's Eat N Tool 9100C Silver Multi Too", mPercentage = 30, mImageUrl = "ddd",mTags="knife",mFav=false,mPrice="€150" },
            new Deal { mPhotoID = 1007, mCaption = "Watershed Dry", mDesc = "Watershed Chattooga Dry Duffel 3 Colors Outdoor Duffel", mPercentage = 10, mImageUrl = "bbb",mTags="bag",mFav=false,mPrice="€50" }

            };

        private ObservableCollection<Deal> _deals = new ObservableCollection<Deal>();
        public ObservableCollection<Deal> Deals
        {
            get { return _deals; }
            set
            {
                if (_deals != value)
                {
                    _deals = value;
                    RaisePropertyChanged();
                }

            }
        }

        public DealViewModel(INavigationService _navigationService)
        {
            _deals = _refDeals;
            navigationService = _navigationService;
        }


        public RelayCommand<Deal> NavigateCommand
        {
            get
            {
                return navigateCommand
                    ?? (navigateCommand = new RelayCommand<Deal>((data) => navigationService.NavigateTo(
                            ViewModelLocator.DetailPageKey, data)));
            }
        }


        public RelayCommand<string> SearchCommand
        {
            get
            {
                return searchCommand
                    ?? (searchCommand = new RelayCommand<string>((searchString) =>
                    {

                        if (searchString != null && searchString.Length > 0)
                        {

                            var result = _refDeals.Where(x => x.mCaption.ToLower().Contains(searchString) || x.mTags.ToLower().Contains(searchString)).AsEnumerable();
                            Deals = new ObservableCollection<Deal>(result);
                        }
                        else
                        {
                            Deals = _refDeals;
                        }

                    }));
            }
        }
    }
}
