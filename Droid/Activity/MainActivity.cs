using Android.App;
using Android.OS;
using Refractored.Fab;
using Android.Support.V7.Widget;
using Deals.Droid.Adapter;
using Android.Widget;
using Android.Content;
using Android.Views;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Ioc;
using Deals.ViewModel;

namespace Deals.Droid
{
    [Activity(Label = "Deals", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ActivityBase
    {
      
        // RecyclerView instance that displays the deal
        RecyclerView mRecyclerView;

        // Layout manager that lays out each card in the RecyclerView:
        RecyclerView.LayoutManager mLayoutManager;

        // Adapter that accesses the data set (a photo album):
        DealAdapter mAdapter;

 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);


            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.AttachToRecyclerView(mRecyclerView);



            // Use the built-in linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);
            // Plug the layout manager into the RecyclerView:
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //............................................................
            // Adapter Setup:

            // Create an adapter for the RecyclerView, and pass it the
            // data set (the photo album) to manage:
            mAdapter = new DealAdapter();


            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter); 

            DispatcherHelper.Initialize();
            var nav = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            nav.Configure(ViewModelLocator.DetailPageKey, typeof(DetailDeal));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);
            return true;
        }
    }


}

