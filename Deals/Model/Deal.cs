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


    }

}
