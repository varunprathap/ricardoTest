using System;
namespace Deals
{
    public class DealCollection
    {


        public static Deal[] deals ={

            new Deal{mPhotoID=1001,mCaption="Lomo'Instant", mDesc="Lomo'Instant Marrakesh Edition Lens Combo Instant Film Camera Flash",mPercentage=50,mImageUrl="aaa"},
            new Deal{mPhotoID=1002,mCaption="Adidas Gazelle Og",mDesc="ADIDAS GAZELLE OG (Q23178) GREEN ADIDAS ORIGINALS CASUAL SHOES SNEAKERS",mPercentage=40,mImageUrl="eee"},
            new Deal{mPhotoID=1003,mCaption="Adidas Dragon ",mDesc="NEW ADIDAS DRAGON (S81908) All Sz ORIGINALS CASUAL SHOES SNEAKERS", mPercentage=10,mImageUrl="ggg"},
            new Deal{mPhotoID=1004,mCaption="adidas Jogger",mDesc="gym shoe new dragon sl 72",mPercentage=40,mImageUrl="fff"},
            new Deal{mPhotoID=1005,mCaption="Columbia River Knife",mDesc="Columbia River Knife and Tool's Eat N Tool 9100C Silver Multi Too", mPercentage=30,mImageUrl="ddd"},
            new Deal{mPhotoID=1007,mCaption="Watershed Chattooga Dry",mDesc="Watershed Chattooga Dry Duffel 3 Colors Outdoor Duffel",mPercentage=10,mImageUrl="bbb"}

        };

        // Array of deals   
        public Deal[] mDeals;

        public DealCollection()
        {

            mDeals = deals;

        }

        // Return the number of deals
        public int DealsCount
        {
            get { return deals.Length - 1; }
        }
    }

}
