using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TAC.Utils.Helpers
{
    public static class SitecoreExtensions
    {
        /// <summary>
        /// Retrieves the base URL of the current site in Sitecore. 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string SitecoreSiteUrl(this HtmlHelper helper)
        {
            return SitecoreExtensions.SitecoreUrl(helper, SitecoreHelper.SiteRootItem());
        }

        /// <summary>
        /// Retrieves the end user friendly URL that matches the specified Sitecore item.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SitecoreUrl(this HtmlHelper helper, Item item)
        {
            if (item != null)
            {

                if (Sitecore.Context.PageMode.IsExperienceEditorEditing)
                {
                    return LinkManager.GetDynamicUrl(item);
                }
                var options = LinkManager.GetDefaultUrlOptions();
                options.SiteResolving = true;
                return LinkManager.GetItemUrl(item, options);
            }
            return string.Empty;
        }

        /// <summary>
        /// Retrieves the user friendly URL from a field on the current item that contains a media item
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string SitecoreMediaUrl(this HtmlHelper helper, string fieldName)
        {
            return SitecoreMediaUrl(helper, fieldName, Sitecore.Context.Item);
        }

        /// <summary>
        /// Retrieves the user friendly URL from a field on a specific item that contains a media item
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SitecoreMediaUrl(this HtmlHelper helper, string fieldName, Item item)
        {
            if (item != null)
            {
                ImageField imgField = item.Fields[fieldName];
                if (imgField != null)
                {
                    MediaItem mediaItem = imgField.MediaItem;
                    if (mediaItem != null)
                    {
                        return Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Retrieves a translation from the Sitecore dictionary based on the key and optional domain name.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="key"></param>
        /// <param name="domain"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static HtmlString Translate(this HtmlHelper helper, string key, string domain = "", params object[] parameters)
        {
            var retValue = string.Empty;
            if (string.IsNullOrEmpty(domain))
            {
                retValue = Sitecore.Globalization.Translate.Text(key, parameters);
            }
            else
            {
                retValue = Sitecore.Globalization.Translate.TextByDomain(domain, key, parameters);
            }

            return new HtmlString(retValue);
        }

        /// <summary>
        /// Retrieves a string from the content of a rendering parameter
        /// A specifiek field (by name) from a item can be retrieved if the parameter contains a reference to an item
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="parameters"></param>
        /// <param name="key"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static HtmlString RenderParameter(this HtmlHelper helper, RenderingParameters parameters, string key, string fieldName)
        {
            var retValue = "";
            if (parameters != null)
            {
                retValue = parameters[key];
                ID itemID = ID.Null;
                if (ID.TryParse(retValue, out itemID) && !string.IsNullOrEmpty(fieldName))
                {
                    var item = Sitecore.Context.Database.GetItem(itemID);
                    if (item != null)
                    {                        
                        retValue = FieldRenderer.Render(item, fieldName, Statics.Parameters.DisableWebEditing);
                        if (string.IsNullOrEmpty(retValue))
                        {
                            retValue = item.DisplayName;
                        }
                    }
                }
            }
            return new HtmlString(retValue);
        }

        /// <summary>
        /// Retrieves a string from the content of a rendering parameter
        /// A specifiek field (by ID) from a item can be retrieved if the parameter contains a reference to an item
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="parameters"></param>
        /// <param name="key"></param>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        public static HtmlString RenderParameter(this HtmlHelper helper, RenderingParameters parameters, string key, ID fieldID)
        {
            return RenderParameter(helper, parameters, key, fieldID.ToString());
        }

        /// <summary>
        /// Renders the content of a referenced field
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="itemField"></param>
        /// <param name="linkField"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static HtmlString RenderLinkField(this HtmlHelper helper, string itemField, string linkField = "", Item item = null)
        {
            var retValue = "";
            if (item == null)
            {
                item = Sitecore.Context.Item;
            }

            retValue = FieldRenderer.Render(item, itemField, Statics.Parameters.DisableWebEditing);
            ID itemID = ID.Null;
            if (ID.TryParse(retValue, out itemID))
            {
                var linkItem = Sitecore.Context.Database.GetItem(itemID);
                if (string.IsNullOrEmpty(linkField))
                {
                    linkField = Sitecore.FieldIDs.DisplayName.ToString();
                }
                retValue = FieldRenderer.Render(linkItem, linkField, Statics.Parameters.DisableWebEditing);

            }
            return new HtmlString(retValue);
        }
    }
}
