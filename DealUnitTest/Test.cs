using NUnit.Framework;
using FluentAssertions;
using GalaSoft.MvvmLight.Views;
using Moq;
using Deals.ViewModel;
using Deals;

namespace DealUnitTest
{
    [TestFixture()]
    public class Test
    {


        private Mock<INavigationService> _mockNavigation;

        [SetUp]

        public void SetUp()
        {
            //Mock navigation service from MVVMLight.
            _mockNavigation = new Mock<INavigationService>();
        }

        //Get a deal 
        private Deal CreateDealModel()
        {
            var dvm = new DealViewModel(_mockNavigation.Object);
            return dvm.Deals[0];

        }

        //Test method should return count of 6 deals.
        [Test]
        public void DealViewModelShouldReturnDealsCount()
        {
            var dvm = new DealViewModel(_mockNavigation.Object);
            dvm.Deals.Count.Should().Be(6);
        }

        //Test method for check favourite.
        [Test]
        public void ExecuteTheFavouriteCommandShouldChangeDealProperty()
        {
            var detailVm = new DetailDealVM(_mockNavigation.Object);
            detailVm.Favourite = false;
            detailVm.AddFavourite.Execute(null);
            detailVm.Favourite.Should().Be(true);

        }

    }
}
