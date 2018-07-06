using System;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace Deals.Droid.Adapter
{
    public class DealFilter:Filter
    {
        public DealFilter(DealAdapter dealAdapter)
        {



        }

        protected override FilterResults PerformFiltering(ICharSequence constraint)
        {
            throw new NotImplementedException();
        }

        protected override void PublishResults(ICharSequence constraint, FilterResults results)
        {
            throw new NotImplementedException();
        }
    }
}
