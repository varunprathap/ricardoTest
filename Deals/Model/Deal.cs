using System;

namespace Deals
{

    public class Deal 
    {

        // Photo ID for this deal:
        public int mPhotoID;

        // Caption text for this deal:
        public string mCaption;

        //Offer percentage for this deal:
        public int mPercentage;

        //Description for this deal:
        public string mDesc;

        //Image for this deal:
        public string mImageUrl;

        //Tag for this deal:
        public string mTags;

        //Favourite for this deal:
        public bool mFav;

        //Done for this deal:
        public bool mDone;

        //Price for this deal;
        public string mPrice;

        // Return the ID of the deal:
        public int PhotoID
        {
            get { return mPhotoID; }
        }

        // Return the Caption of the deal:
        public string Caption
        {
            get { return mCaption; }
        }

        // Return the percentage of the deal:
        public int Percentage
        {
            get { return mPercentage; }
        }


        // Return the description of the deal:
        public string Description
        {
            get { return mDesc; }
        }

        // Return the description of the deal:
        public string ImageUrl
        {
            get { return mImageUrl; }
        }

        //Return the tags of the deal:
        public string Tags{
            get { return mTags; }
        }

        //Return is favourite of the deal:
        public bool Favourite
        {
            get { return mFav; }
        }

        //Return the price of the deal:
        public string Price
        {
            get { return mPrice; }
        }

        //Return the Done of the deal:
        public bool Done
        {
            get { return mDone; }
        }


    }

}
