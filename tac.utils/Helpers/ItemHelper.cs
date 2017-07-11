using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Utils.Helpers
{
    public class ItemHelper
    {
        public static Item GetFooterTextItem() {
            return GetHomeReferenceItem("FooterText");
        }

        public static Item GetSpotlightJobItem()
        {
            return GetHomeReferenceItem("SpotlightJob");
        }

        public static Item GetHomeReferenceItem(string fieldName)
        {
            ReferenceField reference = SitecoreHelper.SiteHomeItem().Fields[fieldName];
            if (reference != null)
            {
                return reference.TargetItem;
            }
            return null;
        }
    }
}
