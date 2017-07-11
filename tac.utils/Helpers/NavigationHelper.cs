using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Utils.Helpers
{
    /// <summary>
    /// Returns a list of Sitecore items that represents the breadcrumb path
    /// </summary>
    public class NavigationHelper
    {
        /// <summary>
        /// retrieves a list of items that are part of the breadcrumb
        /// </summary>
        /// <param name="current"></param>
        /// <param name="overrideExcludeNavigation"></param>
        /// <returns></returns>
        public static ICollection<Item> GetBreadcrumbs(Item current, bool overrideExcludeNavigation = false)
        {
            Item homeItem = SitecoreHelper.SiteRootItem();

            List<Item> breadcrumbs = new List<Item>();

            while (current != null)
            {
                if (overrideExcludeNavigation || (current.Fields[Statics.FieldNames.ExcludeFromNavigation] != null && !((CheckboxField)current.Fields[Statics.FieldNames.ExcludeFromNavigation]).Checked))
                {
                    breadcrumbs.Add(current);
                }

                if (current == homeItem)
                    break;

                current = current.Parent;
            }

            breadcrumbs.Reverse();

            return breadcrumbs;
        }

        /// <summary>
        /// Retrieves a list of items that are part of the Sites meta navigation.
        /// </summary>
        /// <returns></returns>
        public static ICollection<Item> GetMetaNavigation(Item startItem = null)
        {
            if(startItem == null)
            {
                startItem = SitecoreHelper.SiteHomeItem();
            }
            return startItem.Children.Where(x => x.TemplateName == Statics.TemplateNames.ContentPage && !((CheckboxField)x.Fields[Statics.FieldNames.ExcludeFromNavigation]).Checked).ToList();
        }
    }
}
