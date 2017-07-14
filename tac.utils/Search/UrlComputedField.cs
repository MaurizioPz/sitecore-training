using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch;
using Sitecore.Links;

namespace TAC.Utils.Search
{
    class UrlComputedField : AbstractComputedIndexField
    {
        public override object ComputeFieldValue(IIndexable indexable)
        {
            var indexableItem = indexable as SitecoreIndexableItem;
            if (indexableItem == null)
                return null;
            var item = indexableItem.Item;
            var options = LinkManager.GetDefaultUrlOptions();
            options.SiteResolving = true;
            return LinkManager.GetItemUrl(item, options);
        }
    }
}
