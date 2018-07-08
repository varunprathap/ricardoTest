using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Deals.ViewModel
{
    public class DetailDealVM : ViewModelBase
    {
        private readonly INavigationService navigationService;
        public DetailDealVM(INavigationService _navigationService)
        {

            navigationService = _navigationService;
        }


        private string _title;
        //title
        public string Title
        {

            get { return _title; }
            set
            {
                Set(() => Title, ref _title, value);
            }


        }


        private string _price;
        //price.
        public string Price
        {

            get { return _price; }
            set
            {
                Set(() => Price, ref _price, value);
            }


        }

        private string _description;
        //description
        public string Description
        {

            get { return _description; }
            set
            {
                Set(() => Description, ref _description, value);
            }

        }

        private bool _isFavourite;
        //Favourite.
        public bool Favourite
        {

            get { return _isFavourite; }
            set
            {
                Set(() => Favourite, ref _isFavourite, value);
            }

        }

        //Navigation back button.
        private RelayCommand _goBackCommand;
        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(() => navigationService.GoBack()));

        private RelayCommand _addFavourite;
        public RelayCommand AddFavourite => _addFavourite ?? (_addFavourite = new RelayCommand(() =>
        {
            Favourite = !Favourite;
        }));

    }
}
