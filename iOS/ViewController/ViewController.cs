using System;

using UIKit;
using GalaSoft.MvvmLight.Helpers;
using Deals.ViewModel;
using Foundation;
using Deals.iOS.TableCell;

namespace Deals.iOS.ViewController
{
    public partial class ViewController : UIViewController
    {

        private ObservableTableViewController<Deal> tableViewController;

        private DealViewModel dealViewModel => Application.viewModelLocator.Main;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
           
           

            //DealNavigation.Appearance.TintColor = UIColor.FromRGB(213, 0, 0);
            tableViewController = dealViewModel.Deals.GetController(CreateDealCell,BindCellDelegate);
            tableViewController.TableView=DealTableView;
            tableViewController.SelectionChanged += OnItemSelected;
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

        }



        private void BindCellDelegate(UITableViewCell cell,Deal deal,NSIndexPath indexPath){
            var bindCell = (DealTableCell)cell;
            bindCell.Configure(deal);
        }

        private UITableViewCell CreateDealCell(NSString cellIdentifier){
            return DealTableView.DequeueReusableCell("DealTableCell");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }


        void OnItemSelected(object sender, EventArgs e)
        {

            dealViewModel.NavigateCommand.Execute(tableViewController.SelectedItem);
        }
    }
}
