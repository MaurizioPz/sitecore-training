using Microsoft.Owin.Infrastructure;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TAC.Utils.Helpers
{
    public static class NavigationExtensions
    {
        /// <summary>
        /// Checks if the current item matches the target item to be able to set the active state class on a list item.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="targetItem"></param>
        /// <param name="currentItem"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static string IsSelected(this HtmlHelper helper, Item targetItem, Item currentItem = null, string cssClass = Statics.DefaultActiveClass)
        {
            if(currentItem == null)
            {
                currentItem = Sitecore.Context.Item;
            }
            //Always compare two Sitecore items by their ID.
            if(targetItem.ID != currentItem.ID)
            {
                cssClass = string.Empty;
            }
            return cssClass;
        }

        /// <summary>
        /// Renders a very simple querystring based bootstrap pager
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItems"></param>
        /// <param name="currentPage"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static HtmlString Pager(this HtmlHelper helper, int pageSize, int totalItems, int currentPage=-1, string cssClass = Statics.DefaultPagerClass)
        {
            int totalPages = (totalItems / pageSize) + 1;
            int startIndex = 0;
            int endIndex = totalPages;

            //Make sure that there is always an active page, when it is below 1 set it to 1. 
            if (currentPage == -1)
            {
                int.TryParse(HttpContext.Current.Request.QueryString[Statics.QueryStrings.Paging], out currentPage);
                if (currentPage < 1)
                    currentPage = 1;
            }
            //If the current page exeeds the total pages, set the currentpage to the maximaum amount of the total pages.
            if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }

            //Implements the google paging logic.
            if (totalPages > 10)
            {
                startIndex = currentPage - 5;
                endIndex = currentPage + 5;
                if (startIndex < 0)
                {
                    startIndex = 0;
                    endIndex = startIndex + 10;
                }
                if (endIndex > totalPages)
                {
                    endIndex = totalPages;
                    startIndex = totalPages - 10;
                }
            }

            //Builds the pagination list wrapper.
            StringBuilder sb = new StringBuilder();
            var pagerTag = new TagBuilder("ul");
            pagerTag.AddCssClass(cssClass);
            sb.Append(pagerTag.ToString(TagRenderMode.StartTag));
            //Adds a previous link to the page
            if (currentPage > 1)
            {
                sb.Append(PagerItem(Statics.TranslationKeys.Previous, (currentPage - 1), false, false));
            }
            //Adds all the pagination links to the pager
            for (int i = startIndex; i < endIndex; i++)
            {
                sb.Append(PagerItem((i + 1).ToString(), (i + 1), (i + 1) == currentPage, true));
            }
            //Adds a next link to the page
            if (totalPages > 1 && currentPage < totalPages)
            {
                sb.Append(PagerItem(Statics.TranslationKeys.Next, (currentPage + 1), false, false));
            }
            sb.Append(pagerTag.ToString(TagRenderMode.EndTag));
            return new HtmlString(sb.ToString());
        }

        /// <summary>
        /// Renders the links for the simple bootstap pager
        /// </summary>
        /// <param name="text"></param>
        /// <param name="page"></param>
        /// <param name="isActive"></param>
        /// <param name="isPage"></param>
        /// <returns></returns>
        private static HtmlString PagerItem(string text, int page, bool isActive=false, bool isPage = true)
        {
            StringBuilder sb = new StringBuilder();
            var pagerItem = new TagBuilder("li");
            if (isActive) pagerItem.AddCssClass(Statics.DefaultActiveClass);
            var pagerLink = new TagBuilder("a");
            pagerLink.MergeAttribute("href", WebUtilities.AddQueryString(LinkManager.GetItemUrl(Sitecore.Context.Item), Statics.QueryStrings.Paging, page.ToString()));

            switch (text)
            {
                case Statics.TranslationKeys.Previous:
                case Statics.TranslationKeys.Next:
                    pagerItem.MergeAttribute("aria-label", Translate.Text(text));
                    string appsetting = string.Format("Pager.{0}.Text", text);
                    //Added some defaults here, soa patch file is not alwayse needed.
                    var defaultValue = Statics.HtmlEncodedChars.Raquo;
                    if(text == Statics.TranslationKeys.Previous) {
                        defaultValue = Statics.HtmlEncodedChars.Laquo;
                    }
                    var ariaSpan = new TagBuilder("span");
                    ariaSpan.MergeAttribute("aria-hidden", "true");
                    ariaSpan.InnerHtml = Sitecore.Configuration.Settings.GetSetting(appsetting, defaultValue);
                    pagerLink.InnerHtml = ariaSpan.ToString();
                    break;
                default:
                    pagerLink.SetInnerText(text);
                    break;
            }

            sb.Append(pagerItem.ToString(TagRenderMode.StartTag));
            sb.Append(pagerLink.ToString(TagRenderMode.Normal));
            sb.Append(pagerItem.ToString(TagRenderMode.EndTag));
            return new HtmlString(sb.ToString());
        }
    }
}
