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

        public string Title
        {

            get { return _title; }
            set
            {
                Set(() => Title, ref _title, value);
            }


        }
        private string _description;
        public string Description
        {

            get { return _description; }
            set
            {
                Set(() => Description, ref _description, value);
            }

        }

        private bool _isFavourite;


        public bool Favourite
        {
            
            get { return _isFavourite; }
            set
            {
                Set(() => Favourite, ref _isFavourite, value);
            }

        }

        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(() => navigationService.GoBack()));

        private RelayCommand _addFavourite;
        public RelayCommand AddFavourite => _addFavourite ?? (_addFavourite = new RelayCommand(() => {

            Favourite = !Favourite;
        }));

    }
}
