using Android.App;
using Android.OS;
using Refractored.Fab;
using Android.Support.V7.Widget;
using Deals.Droid.Adapter;
using Android.Content;
using Android.Views;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Ioc;
using Deals.ViewModel;
using JimBobBennett.MvvmLight.AppCompat;
using GalaSoft.MvvmLight.Helpers;
using Android.Support.V4.View;
using Android.Runtime;
using Android.Graphics;

namespace Deals.Droid
{
    [Activity(Label = "Deals", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivityBase
    {
      
        // RecyclerView instance that displays the deal
        RecyclerView mRecyclerView;

        // Layout manager
        RecyclerView.LayoutManager mLayoutManager;

        // Adapter that accesses the data set
        DealAdapter mAdapter;

        SearchView _searchView;
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Initialize the dispatcher and navigation service.
            DispatcherHelper.Initialize();
            var nav = new AppCompatNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            nav.Configure(ViewModelLocator.DetailPageKey, typeof(DetailDeal));

            SetContentView(Resource.Layout.Main);


            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            toolbar.SetBackgroundColor(Color.ParseColor("#d50000"));
            SetSupportActionBar(toolbar);

            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);


            //var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fab.AttachToRecyclerView(mRecyclerView);



            // Use the built-in linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);

            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Adapter Setup:

            mAdapter = new DealAdapter();


            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);

          


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
             
            MenuInflater.Inflate(Resource.Menu.main, menu);
            var item = menu.FindItem(Resource.Id.action_search);

            //serachview placeholder text.
            _searchView = (SearchView)item.ActionView;
            _searchView.QueryHint = "search bag,shoe etc.";

            //serachview textchange event and bind to view model.
            _searchView.QueryTextChange += (s, e) =>
            {
                ViewModelLocator.dealViewModel.SearchCommand.Execute(_searchView.Query?.ToLower().ToString());
            };
           
            return true;
        }

        protected override void OnResume()
        {
            base.OnResume();
            if(_searchView!=null){
                _searchView.SetQuery("",false);
                _searchView.ClearFocus();

            }

        }
    }


}

