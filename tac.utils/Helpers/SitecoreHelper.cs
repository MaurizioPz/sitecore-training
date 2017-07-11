using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Utils.Helpers
{
    public class SitecoreHelper
    {
        /// <summary>
        /// Retrives the Sitecore item that is considered the root for the current site.
        /// </summary>
        /// <returns></returns>
        public static Item SiteRootItem()
        {
            return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath);
        }

        /// <summary>
        /// Retrieves the Sitecore item that is considered the home item for the current site.
        /// </summary>
        /// <returns></returns>
        public static Item SiteHomeItem()
        {
            return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
        }

        public static ICollection<Item> GetMultiListItems(string fieldName, Item source = null)
        {
            if (source == null) source = Sitecore.Context.Item;
            MultilistField mlf = source.Fields[fieldName];
            if(mlf != null)
            {
                return mlf.GetItems().ToList();
            }
            return new List<Item>();
        }
    }
}
